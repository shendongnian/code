     using UnityEngine;
     using System.Collections;
     public class GetMeshRenderer : MonoBehaviour 
     {
	   private MeshRenderer ShowZone;
	// Use this for initialization
	void Start () 
	{
		ShowZone = gameObject.GetComponent<MeshRenderer> (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Y))
		{
			ShowZone.enabled = true;		 
		}
		if(Input.GetKey(KeyCode.N))
		{
			ShowZone.enabled = false;	
		}
	
	}
} 
   
