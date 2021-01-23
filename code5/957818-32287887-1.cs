	void DoSomehtingCool()
	{
		var factory = new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext());
		factory.StartNew(() =>
		{
			var result = await IntensiveComputing();
			txtLog.AppendText("Result of the computing: " + result);
		});
	}
	async Task<double> IntensiveComputing()
	{
		Thread.Sleep(5000);
		return 20;
	}
