	var cancellationTokenSource = new CancellationTokenSource();
	var cancellationToken = cancellationTokenSource.Token;
	// take the first firefox instance once; if you know the PID you can use Process.GetProcessById(PID);
	var firefox = Process.GetProcessesByName("firefox").FirstOrDefault();
	var timer = new System.Threading.Tasks.Task(() =>
	{
		cancellationToken.ThrowIfCancellationRequested();
		// poll
		while (true)
		{
			checkMemory(firefox);
			// we want to exit
			if (cancellationToken.IsCancellationRequested)
			{
				cancellationToken.ThrowIfCancellationRequested();
			}
			// give the system some time
			System.Threading.Thread.Sleep(1000);
		}
	}, cancellationToken);
	// start the polling task
	timer.Start();
	// poll for 2,5 seconds
	System.Threading.Thread.Sleep(2500);
	// stop polling
	cancellationTokenSource.Cancel();
