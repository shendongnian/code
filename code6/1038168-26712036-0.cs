    using UnityEngine;
    using System;
    
    public class Patrol : MonoBehavior 
    {
    	public int patrolID;
    	
    	public GameObject FindNextPoint() 
    	{
    		GameObject base;
    		foreach(GameObject go in GameObject.FindGameObjectsWithTag("PatrolPoint")) 
    		{
    			if(base == null && go.GetComponent<Patrol>().patrolID != patrolID) 
    			{
    				base = go;
    			}
    			if(go.GetComponent<Patrol>().patrolID == (patrolID) + 1) {
    				return go;
    			}
    		}
    		// Return the first object found in the scene that isn't this object.
    		return base
    	}
    	
    }
