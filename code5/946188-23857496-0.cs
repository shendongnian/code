    private void StartGame()
    {
    	if (this.InvokeRequired)
    	{
    		Action invoke = new Action(StartGame);
    		this.Invoke(invoke);
    	}
    	else
    	{
    		Hide();
    		controller.StartGame();
    		Close();
    	}
    }
