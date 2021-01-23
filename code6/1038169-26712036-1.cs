    using UnityEngine;
    using System.Collections;
    
    public class NpcScript : MonoBehaviour 
    {
    
    	private Vector3 targetLocation;
    	
        void OnTriggerEnter(Collider other) 
    	{
            if(other.gameObject.tag == "PatrolPoint")
    		{
    			setWalkTo(other.gameObject);
    		}
        }
    	
    	void setWalkTo(GameObject go) 
    	{
    		targetLocation = go.GetComponent<Patrol>().FindNextPoint().transform.position;
    	}
    	
    }
