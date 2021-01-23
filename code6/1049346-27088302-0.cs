	public void DoProcess()
	{
		var task = Task.Factory.StartNew(() => problematicMethod());
	
		//do more processing in main thread
		//    ...
		//    ...
		//    ...
	
		var result = task.Result;
	}
