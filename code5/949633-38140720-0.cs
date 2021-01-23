	var task = new Task(() =>
		{
			Console.WriteLine("My task...");
			throw new Exception();
		});
	task.Start();
	var taskNotOnFaulted = task.ContinueWith(t =>
	{
		Thread.Sleep(1000);
		Console.WriteLine("NotOnFaulted");
	}, TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
	var taskOnlyOnFaulted = task.ContinueWith(t =>
	{
		Thread.Sleep(1000);
		Console.Write("OnlyOnFaulted");
	}, TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
	Task.WaitAny(taskNotOnFaulted, taskOnlyOnFaulted);
	Console.WriteLine("Finished");
