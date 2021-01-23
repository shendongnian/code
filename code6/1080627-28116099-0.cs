	private static void Main()
	{
		using (Semaphore semaphore = new Semaphore(3, 3, "testing"))
		{
			if (!semaphore.WaitOne(100))
			{
				Console.WriteLine("Sorry too late");
				Environment.Exit(0);
			}
		    Console.WriteLine("Hello world");
   		    Thread.Sleep(100000000);
		} 
	}
