    while(!cancellationTokenSource.Token.IsCancellationRequested)
    {
        lock (locker)
        {
            DoSomething(); //consider passing the token here if it takes a while...
        }
        DoAnotherThing(); //and here...
        try
        {
            Task.Delay(1000, cancellationTokenSource.Token);    
        }
        catch(TaskCanceledException)
        {
            break;
        }
    }
