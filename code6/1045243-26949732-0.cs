    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    public class ListTest : MonoBehaviour
    {
	    List<string> listA = new List<string>();
    	List<string> listB;
	    void Start()
	    {
		    listA.Add("a");
		    listA.Add("b");
     		listB = listA;
	    	listB.Add("c");
		    listB.Remove("a");
            listA.Add("d");
		
		    Debug.Log("List A:");
		    foreach(string item in listA)
			    Debug.Log(item);
    		Debug.Log("List B:");
	     	foreach(string item in listB)
		    	Debug.Log(item);
        }
    }
