    void Test()
    {
        var tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;
        Task child = null;
        var parent = Task.Factory.StartNew(() =>
        {
            child = Task.Factory.StartNew(() =>
            {
                while (!token.IsCancellationRequested)
                    Thread.Sleep(100);
                token.ThrowIfCancellationRequested();
            }, token, TaskCreationOptions.AttachedToParent, TaskScheduler.Default);
		
            while (!token.IsCancellationRequested)
                Thread.Sleep(100);
            token.ThrowIfCancellationRequested();
        }, token);
        Thread.Sleep(500);
        Debug.WriteLine("State of parent before cancel is {0}", parent.Status);
        Debug.WriteLine("State of child before cancel is {0}", child.Status);
        tokenSource.Cancel();
        Thread.Sleep(500);
        Debug.WriteLine("State of parent is {0}", parent.Status);
        Debug.WriteLine("State of child is {0}", child.Status);
    }
