    public static Task<bool> FromWaitHandle(WaitHandle handle, TimeSpan timeout)
    {
        // Handle synchronous cases.
        var alreadySignalled = handle.WaitOne(0);
        if (alreadySignalled)
            return Task.FromResult(true);
        if (timeout == TimeSpan.Zero)
            return Task.FromResult(false);
        // Register all asynchronous cases.
        var tcs = new TaskCompletionSource<bool>();
        var threadPoolRegistration = ThreadPool.RegisterWaitForSingleObject(handle,
            (state, timedOut) => ((TaskCompletionSource<bool>)state).TrySetResult(!timedOut),
            tcs, timeout);
        tcs.Task.ContinueWith(_ =>
        {
            threadPoolRegistration.Dispose();
        }, TaskScheduler.Default);
        return tcs.Task;
    }
