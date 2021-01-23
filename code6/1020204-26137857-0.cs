	ManualResetEvent _resetEvent;
	public void StartWatch()
	{
		// Start watching...
        // Wait until signaled.
		_resetEvent = new ManualResetEvent(false);
		_resetEvent.WaitOne();
	}
	static void watcher_Created(object sender, FileSystemEventArgs e)
	{
		// Handle your file...
        // And signal.
		_resetEvent.Set();	
	}
