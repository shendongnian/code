    public List<GameObject> FindInactiveGameObjects()
	{
		GameObject[] all = GameObject.FindObjectsOfType<GameObject> ();//Get all of them in the scene
		List<GameObject> objs = new List<GameObject> ();
		foreach(GameObject obj in all) //Create a list 
		{
			objs.Add(obj);
		}
		Predicate inactiveFinder = new Predicate((GameObject go) => {return !go.activeInHierarchy;});//Create the Finder
		List<GameObject> results = objs.FindAll (inactiveFinder);//And find inactive ones
		return results;
	}
