	public void ClickEventHandler(int x, int y)
	{
		// The "Click" event was raised on the COM server, handle the event here
	}
	EventSource.Button myButton = new EventSource.Button();
	myButton.Click += new EventSource.ClickDelegate(ClickEventHandler); // subscribe to the event
