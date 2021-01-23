    public Task Login(string userName, Action<bool> callback)
    {
        // The delegate passed to `Task.Factory.StartNew`
        // is executed on a ThreadPool thread.
        var task = Task.Factory.StartNew(() => _proxy.Login(userName));
        // The callback is executed on the thread which called Login.
        var continuation = task.ContinueWith(
            t => callback(t.Result),
            TaskScheduler.FromCurrentSynchronizationContext()
        );
        return continuation;
    }
