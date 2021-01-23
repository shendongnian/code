	void DoWork(Action<object, EventArgs> handler)
	{
		if (condition)
		{
			OnSomeEvent(this, EventArgs.Empty);
		}
	}
	void OnSomeEvent(object sender, EventArgs e)
	{
		
	}
