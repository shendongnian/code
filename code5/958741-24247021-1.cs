    class MyWorker {
    CancellationToken ct = <from ctor>;
    TaskCompletionSource<object> shutdownCompletedTcs = new ...();
    
    public void Run()
    {
        for (int i = 0; i < count && !ct.IsCancellationRequested; i++)
        {
            // do stuff
    
            OnProgressMade((float)i / (float)count);
        }
    
        //OnWorkFinished(); //old
        shutdownCompletedTcs.SetResult(null); //new, set "event"
    }
    
    public Task WaitForShutdown() {
     return shutdownCompletedTcs.Task;
    }
    }
