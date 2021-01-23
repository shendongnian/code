    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
    public class NewBehaviourScript : MonoBehaviour
    {
    	string[] keywords;
    	bool[] kws;
    
    	void Awake()
    	{
    		int amount = 27;
    		keywords = new string[amount];
    		kws = new bool[amount];
    		for (int i = 0; i < amount; i++) keywords[i] = "" + i;
    	}
    	
    	void OnGUI()
    	{
    		int columns = 4;
    		int x, y;
    		for (int index = 0; index < keywords.Length; index++)
    		{
    			x = 100 * (index % columns);
    			y =  30 * (index / columns) + 30;
    			bool oldValue = kws[index];
    			kws[index] = GUI.Toggle(new Rect (x, y, 100, 30), kws[index], keywords[index]);
    			if (kws[index] != oldValue)
    			{
    				Debug.Log("Switched: " + keywords[index] + " to " + kws[index]);
    			}
    		}
    	}
    }
