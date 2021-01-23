    // fake outcome() method for testing
    bool outcome() { return new Random().Next(0, 99) > 50; }
    // with async/await
    async Task<bool> WaitForItToWorkAsync()
    {
        var succeeded = false;
        while (!succeeded)
        {
            succeeded = outcome(); // if it worked, make as succeeded, else retry
            await Task.Delay(1000);
        }
        return succeeded;
    }
    
    // without async/await
    Task<bool> WaitForItToWorkAsyncTap()
    {
        var context = TaskScheduler.FromCurrentSynchronizationContext();
        var tcs = new TaskCompletionSource<bool>();
        var succeeded = false;
        Action closure = null;
    
        closure = delegate
        {
            succeeded = outcome(); // if it worked, make as succeeded, else retry
            Task.Delay(1000).ContinueWith(delegate
            {
                if (succeeded)
                    tcs.SetResult(succeeded);
                else
                    closure();
            }, context);
        };
    
        // start the task logic synchronously
        // it could end synchronously too! (e.g, if we used 'Task.Delay(0)')
        closure();
    
        return tcs.Task;
    }
    
    // start both tasks and handle the completion of each asynchronously
    private void StartWaitForItToWork()
    {
        WaitForItToWorkAsync().ContinueWith((t) =>
        {
            MessageBox.Show("WaitForItToWorkAsync complete: " + t.Result.ToString());
        }, TaskScheduler.FromCurrentSynchronizationContext());
    
        WaitForItToWorkAsyncTap().ContinueWith((t) =>
        {
            MessageBox.Show("WaitForItToWorkAsyncTap complete: " + t.Result.ToString());
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }
    
    // await for each tasks (StartWaitForItToWorkAsync itself is async)
    private async Task StartWaitForItToWorkAsync()
    {
        bool result = await WaitForItToWorkAsync();
        MessageBox.Show("WaitForItToWorkAsync complete: " + result.ToString());
    
        result = await WaitForItToWorkAsyncTap();
        MessageBox.Show("WaitForItToWorkAsyncTap complete: " + result.ToString());
    }
