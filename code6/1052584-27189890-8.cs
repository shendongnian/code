    private Task _proccessSmsQueueTask;
    private CancellationTokenSource _cancellationTokenSource;
    protected override void OnStart(string[] args)
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _proccessSmsQueueTask = Task.Run(() => DoWorkAsync(_cts.Token));
    }
    
    protected override void OnStop()
    {
        _cancellationTokenSource.Cancel();
        try
        {
            _proccessSmsQueueTask.Wait();
        }
        catch (Exception e)
        {
            // handle exeption
        }
    }
