    using UnityEngine;
    using System;
    
    public class Example : MonoBehaviour 
    {
    	void OnTriggerEnter(Collider collider) 
    	{
    		if(collider.gameObject.tag == "platform") 
    		{
    			Destroy(gameObject);
    		}
    	}
    }
