	void Start () 
	{
		StartCoroutine(SpawnItemsFromArray());
	}
	IEnumerator SpawnItemsFromArray() //You can name this however you like
	{
		//Instantiates another camera as a GameObject (easy access to Components and removal of Camera)
		GameObject cam1 = Instantiate(GameObject.FindWithTag("MainCamera"), Vector3.zero, Quaternion.FromToRotation(new Vector3(0, 0, 0), new Vector3(0, 0, 1))) as GameObject;
		//Gets AudioListener Component and disables it
		cam1.GetComponent<AudioListener>().enabled = false;
		float space = 1;
		float originalSpace = -3;
		for (int i = 0; i < objectsToSpawn.Length; i++)
		{
			//You'll have to Instantiate as a GameObject to change its tag
			GameObject go = Instantiate(objectsToSpawn[i], new Vector3(originalSpace, 0, 10.0f), transform.rotation) as GameObject;
			originalSpace += space;
			//Changes the tag to "Holder"
			go.tag = "Holder";
			//This will change the tag of the GameObject that this script is attached too
			//gameObject.tag = "Holder"; 
		}
		//Waits for 2 Sec
		yield return new WaitForSeconds(2);
		//This will destroy (new Camera) and all that have tag "Holder"
		GameObject[] goDestroy = GameObject.FindGameObjectsWithTag("Holder");
		foreach (GameObject goHolder in goDestroy) Destroy(goHolder);
		Destroy(cam1);
	}
