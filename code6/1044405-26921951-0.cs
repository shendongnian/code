    var cts = new CancellationTokenSource();
	Task t = Task.Factory.StartNew(
	async () => {
	while (true)
	{
		cts.Token.ThrowIfCancellationRequested();
		try
		{
			"Running...".Dump();
			await Task.Delay(500, cts.Token);
		}
		catch (TaskCanceledException ex) { }
	} }, cts.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default).Unwrap();
