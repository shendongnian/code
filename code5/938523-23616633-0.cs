    CancellationTokenSource cancelSource = new CancellationTokenSource();
    
    public override void Run()
    {
        //do stuff
        cancelSource.Token.WaitHandle.WaitOne();
    }
    
    public override void OnStop()
    {
        cancelSource.Cancel();
    }
