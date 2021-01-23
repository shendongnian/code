    private TaskCompletionSource<object> _tcs;
    public void CreateThreads(int n)
    {
        _tcs = new TaskCompletionSource<object>();
        tokenSource = new CancellationTokenSource();
        token = tokenSource.Token;
        for (int i = 0; i < n; i++)
        {
            workers.Add(DoSomething(_tcs.Task, token));
        }
    }
