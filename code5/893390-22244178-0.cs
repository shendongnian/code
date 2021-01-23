    using UnityEngine;
    using System.Collections;
    
    public class Test : MonoBehaviour
    {
    
    
        private Eaten someScript;
    
    	// start new!
    	public bool eaten
    	{
    
    		get
    		{
    			return someScript.Eaten;
    		}
    
    		set
    		{
    			someScript.Eaten = value;
    		}
    	}
    	// end new!
    
        // Use this for initialization
        void Start ()
        {
            someScript = GetComponent<IsEaten>();
            bool temp = someScript.Eaten;
            print(temp); // false
        }
    }
