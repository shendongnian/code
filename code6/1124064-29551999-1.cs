	void Start()
	{
		str = "Your sentence here";
	}
    void Update() 
    {
		if (Input.GetKeyDown("space"))
		{
			StopCoRoutine("TypeText");
			gameObject.GetComponent<Text>().text = str;
		}
	}
