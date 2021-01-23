    void Update() 
	{
		int i = 0;
		while (i < Input.touchCount)
		{
			if (Input.GetTouch(i).position.x > joystick_center.x - 150 && Input.GetTouch(i).position.x < joystick_center.x + 150)
			{
				if (Input.GetTouch(i).phase != TouchPhase.Ended && Input.GetTouch(i).phase != TouchPhase.Canceled && playerDataScript.playerStatus == "alive")
				{
					//joystick movement code
				} else {
					// reset joystick movement
				}
			}
			++i;
		}
	}
