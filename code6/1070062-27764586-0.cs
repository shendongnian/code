	System.Threading.Tasks.Task
	.Run(() => 
	{
		// simulate processing
		for (var i = 0; i < 10; i++)
		{
			Console.WriteLine("do something {0}", i + 1);
		}
	})
	.ContinueWith(t => Console.WriteLine("done."));
