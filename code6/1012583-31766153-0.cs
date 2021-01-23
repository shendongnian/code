    public bool Start(HostControl hostControl)
    {
        var cancellationToken = cancellationTokenSource.Token;
        this.mainTask = Task.Factory.StartNew(() =>
            {
                while (!this.cancellationTokenSource.IsCancellationRequested)
                {                
                    try
                    {
                        // ... service logic ...
                        throw new Exception("oops!");
                    }
                    catch (Exception)
                    {
                        hostControl.Stop();
                    }
                }
            });
        return true;
    }
