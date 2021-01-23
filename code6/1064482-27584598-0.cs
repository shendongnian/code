    using UnityEngine;
    using System.Collections;
    
    public class Pause : TouchLogicV2  {
    	bool pause = false;
    	GUITexture pauseGUI;
    	//pauseGUI.enabled = false;  This must be done inside a function 
    	
    	public override void OnTouchBegan()
    	{
    		if(pause==true){
    			pause = false;
    		}
    		else {
    			pause = true;
    		} if(pause == true) {
    			Time.timeScale = 0.0F; //Must have F at the end of the number
    			pauseGUI.enabled = true;
    		}
    		else {
    			Time.timeScale = 1.0F; //Must have F at the end of the number
    			pauseGUI.enabled = false; 
    		}
    	} 
    }
