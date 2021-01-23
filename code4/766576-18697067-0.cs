    private static async void Test()
    {
    	var source = new CancellationTokenSource();
    	var watcher = Task.Delay(TimeSpan.FromSeconds(4), source.Token);
    	var downloadTask = Task.Factory.StartNew(() =>
    	                                         {
    		                                         //.. Simulating a long time task
    		                                         Thread.Sleep(TimeSpan.FromSeconds(10));
    	                                         },
    		source.Token);
    	await Task.Run(() => { Task.WaitAny(watcher, downloadTask); });
    	source.Cancel();
    	if (!downloadTask.IsCompleted)
    		Console.WriteLine("Time out!");
    	else
    		Console.WriteLine("Done");
    }
