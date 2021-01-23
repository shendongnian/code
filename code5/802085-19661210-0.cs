    private CancellationTokenSource _tokenSource = new CancellationTokenSource();
    private Task _task;
    
    public void StartDoingSomething()
    {
        if (_task == null)
        {
            _task = Task.Factory.StartNew(Worker, _tokenSource.Token)
                                .ContinueWith(_ => _task = null);
        }
    }
    
    public void StopDoingSomething()
    {
        if (_task != null)
        {
            _tokenSource.Cancel();
        }
    }
    
    private void Worker()
    {
        while (!_tokenSource.IsCancellationRequested)
        {
            // Do some unit of work
        }
    }
