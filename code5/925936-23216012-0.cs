	static readonly ManualResetEvent reset = new ManualResetEvent(false);
	
	static void Main(string[] args)
	{
		var t = new Timer(TimerCallback, null, -1, 1000);
		t.Change(0, 1000);
		reset.WaitOne(); // the application will sit here until the timer tells it to continue.
	}
	
	private static void TimerCallback(object state)
	{
		try
		{ 
		   // do stuff.
		}
		catch (Exception e)
		{
			failureCounter++;
			if (failureCounter > 5)
			{
				reset.Set(); // release the reset event and the application will exit,
				return;
			}
		}
	}
