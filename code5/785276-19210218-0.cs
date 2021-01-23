	// Use this for initialization
	private bool PopUp;
	public string Info;
	
	void OnMouseDown()
	{
		PopUp = true;
	}
	void DrawInfo()
	{
		Rect rect = new Rect (20,20, 300, 200);
		Rect close = new Rect (300,20,20,20);
		if (PopUp)
		{
			GUI.Box(rect, Info);
			if (GUI.Button(close,"X"))
			{
				PopUp = false;
			}
		}
	}
	void OnGUI()
	{
		DrawInfo();
	}
