	void DoSomehtingCool()
	{
		Task.Run(() =>
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
