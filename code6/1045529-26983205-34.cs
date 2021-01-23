    public Task SynchronizeAsync()
    {
        var gch = GCHandle.Alloc(tcs);
        return tcs.Task.ContinueWith(
            t => { gch.Free(); return t; },
            TaskContinuationOptions.ExecuteSynchronously).Unwrap();
    }
