    using UnityEngine;
    using System.Collections;
    public class GetMeshRenderer : MonoBehaviour 
    {
	public MeshRenderer ShowZone;
	
	void Start () 
	{
		 
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
