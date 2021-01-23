    private Task _proccessSmsQueueTask;
    private CancellationTokenSource _cancellationTokenSource;
    protected override void OnStart(string[] args)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _proccessSmsQueueTask = DoWorkAsync(_cts.Token);
    }
    
    protected override void OnStop()
	{
		_cancellationTokenSource.Cancel();
        _proccessSmsQueueTask.Wait();
	}
