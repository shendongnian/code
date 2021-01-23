	private Mover playerMover;
	void Start()
	{
		playerMover = GameObject.Find("Character").GetComponent<Mover>();
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButton(0)) 
		{
			Debug.Log("pressed");
			playerMover.MoveButtonPressed();
		}
	}
