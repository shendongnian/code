        using UnityEngine;
        using System.Collections;
        
        public class RenderController : MonoBehaviour {
        
            // Check PlayerPrefs in Awake() to see if renderer should be enabled
        	void Awake(){
        		if (PlayerPrefs.GetInt ("rendererOn") == 0) {
        			renderer.enabled = true;
        		}
        		else
        			renderer.enabled = false;
        	}
        
        	void OnMouseDown(){
                // If the renderer is enabled when clicked on then disable renderer
        		if (renderer.enabled == true) {
        			renderer.enabled = false;
        			PlayerPrefs.SetInt("rendererOn",1);// Set state to 1(false)in PlayerPrefs
        		}
                // If the renderer is disabled when clicked then enable it
        		else if(renderer.enabled == false){
        			renderer.enabled = true;
        			PlayerPrefs.SetInt("rendererOn",0);// Set state to 0(true)in PlayerPrefs
        		}
        	}  
        }
