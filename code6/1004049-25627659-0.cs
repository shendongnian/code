    private static void DoSomeWork()
    {
        BlockingCollection<int> coll = new BlockingCollection<int>();
    	CancellationTokenSource source = new CancellationTokenSource();
    	ThreadPool.QueueUserWorkItem((s) =>
    	{
    	    Console.WriteLine("Thread started. Waiting for item or cancellation.");
    		try
    		{
    			var x = coll.Take(source.Token);
    			Console.WriteLine("Take completed.");
    		}
    		catch (OperationCanceledException)
    		{
    			Console.WriteLine("Take cancelled. IsCancellationRequested={0}", source.IsCancellationRequested);
    		}
    	});
        Console.WriteLine("Press ENTER to cancel wait.");
        Console.ReadLine();
        source.Cancel(false);
        Console.WriteLine("Cancel sent. Press Enter to exit.");
        Console.ReadLine();
    }
