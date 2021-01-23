    using UnityEngine;
    using System.Collections;
    
    public class Demo : MonoBehaviour {
    	bool clicked = false;
    
    	void OnGUI() {
    		clicked = GUI.Button(new Rect(10, 10, 100, 20), new GUIContent("Click me", "This is the tooltip"));
    		GUI.Label(new Rect(10, 40, 100, 40), GUI.tooltip);
    		if(clicked)
    		{
    		//do your stuff after click	
               print(clicked);
    		}
    	}
    }
