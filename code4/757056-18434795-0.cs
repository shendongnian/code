    using UnityEngine;
    using System.Collections;
    
    public class GUITest : MonoBehaviour {
    
    	private Rect windowRect = new Rect (20, 20, 120, 50);
    
    	void OnGUI () {
    		windowRect = GUI.Window (0, windowRect, WindowFunction, "My Window");
    	}
    
    	void WindowFunction (int windowID) {
    		// Draw any Controls inside the window here
    	}
    
    }
