     GameObject g = Selection.activeGameObject;
	if (g != null)
	{
	    Transform t  = g.transform;
	    foreach (Transform sub in t)  
		{
			Debug.Log(sub); // do something with the sub here
		}
			
	}
