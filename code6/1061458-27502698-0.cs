    using UnityEngine;
    using System.Collections.Generic;
    
    public class KeyboardState : MonoBehaviour {
    
    	/// <summary>
    	/// Keyboard input history, lower indexes are newer
    	/// </summary>
    	public List<HashSet<KeyCode>> history=new List<HashSet<KeyCode>>();
    
    
    	/// <summary>
    	/// How much history to keep?
    	/// history.Count will be max. this value
    	/// </summary>
    	[Range(1,1000)]
    	public int historyLengthInFrames=10;
    
    
    	void Update() {
    		var keysThisFrame=new HashSet<KeyCode>();
    		if(Input.anyKeyDown)
    			foreach(KeyCode kc in System.Enum.GetValues(typeof(KeyCode)))
    				if(Input.GetKey(kc))
    					keysThisFrame.Add(kc);
    		history.Insert(0, keysThisFrame);
    		int count=history.Count-historyLengthInFrames;
    		if(count > 0)
    			history.RemoveRange(historyLengthInFrames, count);
    	}
    
    
    	/// <summary>
    	/// For debug Purposes
    	/// </summary>
    	void OnGUI() {
    		for(int ago=history.Count-1; ago >= 0; ago--) {
    			var s=string.Format("{0:0000}:", ago);
    			foreach(var k in history[ago])
    				s+="\t"+k;
    			GUILayout.Label(s);
    		}
    	}
    
    }
