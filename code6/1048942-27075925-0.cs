    using UnityEngine;
    using System.Collections;
    public class HoverGUI : MonoBehaviour {
	    public string message = "Foo Bar";
    	public float guiDelay = 0.1f;
    	private float lastHoverTime = -99.0f;
    	void OnMouseOver() {
    		lastHoverTime = Time.timeSinceLevelLoad;
    	}
    
    	void OnGUI(){
    		if(lastHoverTime + guiDelay > Time.timeSinceLevelLoad){
    			GUI.Box(new Rect(0,0,170,250),message);
    		}
    	}
    }
