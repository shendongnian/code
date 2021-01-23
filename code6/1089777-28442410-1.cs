	public void Update()
	{
		mouseState = Mouse.GetState();
		if (titleButton1Rectangle.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)))
		{
			if (Mouse.GetState().RightButton == ButtonState.Pressed)
			{
				 ///this should switch screens
				 GlobalVar.activescreen = 1;
                 //variable changes so you now have to update the member CurrentScreen to reflect the change hence the example of below
                 manageScreensInstance.UpdateCurrentScreen();
			}
		 }
	 }
