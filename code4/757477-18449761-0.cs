	private static Task DoIOWorkAsync()
	{
		Console.WriteLine("Doing work...");
		Task work = new Task(() => Thread.Sleep(1500));
		work.Start();
		return work;
	}
