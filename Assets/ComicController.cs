using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicController : MonoBehaviour {

	[SerializeField]
	public List<Panels> ListofPanels  = new List<Panels>();

	public float dissolveSpeedMult;
	[SerializeField]
	private int PanelNumber = -1;

	void Start()
	{
	}
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0) && PanelNumber != ListofPanels.Count-1)
		{
			PanelNumber++;
		}
		if(PanelNumber <= ListofPanels.Count && PanelNumber != -1)
		{
			foreach(GameObject quad in ListofPanels[PanelNumber].Quads)
			{
				float Dissolve = quad.GetComponent<MeshRenderer>().material.GetFloat("Vector1_56F56B9A");
				if(Dissolve > -1)
				{
					quad.GetComponent<MeshRenderer>().material.SetFloat("Vector1_56F56B9A", Dissolve - Time.deltaTime/dissolveSpeedMult);
				}
			}
			if(PanelNumber >= 1)
			{
				foreach(GameObject quad in ListofPanels[PanelNumber-1].Quads)
				{				
					float Dissolve = quad.GetComponent<MeshRenderer>().material.GetFloat("Vector1_56F56B9A");
					
					Debug.Log("away" + Dissolve);
					if(Dissolve <= 1 && ListofPanels[PanelNumber-1].TT == TransitionType.Fade)
					{
						quad.GetComponent<MeshRenderer>().material.SetFloat("Vector1_56F56B9A", Dissolve + Time.deltaTime/dissolveSpeedMult);
					}
				}
			}
		}
	}
}
public enum TransitionType {Stay,Fade};
[System.Serializable]
public class Panels
{
	public GameObject[] Quads;
	public TransitionType TT;
}
