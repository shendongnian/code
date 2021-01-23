    int delay = 1;
    var cancellationTokenSource = new CancellationTokenSource();
    var token = cancellationTokenSource.Token;
    var listener = Task.Factory.StartNew(() =>
    {
    	while(true)
    	{
    		Thread.Sleep(delay);
    		if (token.IsCancellationRequested)
    		{
    			break;
    		}
    	}
    }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
