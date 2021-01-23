	static void Main()
	{
		var clt = new CancellationTokenSource();
		clt.CancelAfter(1000);
		for (int i = 0; i < 10; i++)
		{
			Task.Run(() => Do(clt.Token));
		}
		Console.ReadLine();
	}
	
	private static void Do(CancellationToken cltToken)
	{
		Console.WriteLine("Start " + Task.CurrentId);
		Thread.Sleep(2000);
	
		if (!cltToken.IsCancellationRequested)
		{
			Console.WriteLine("End " + Task.CurrentId);
		}
		else
		{
			Console.WriteLine("Cancelled "+ Task.CurrentId);
		}
	}
