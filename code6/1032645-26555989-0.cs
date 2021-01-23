    using UnityEngine;
    
    public class NotMonoBehaviour
    {
    	private GameObject gObject;
    	
    	public NotMonoBehaviour()
    	{
    		gObject = Resources.Load("MyPrefab") as GameObject;
    	}
    }
