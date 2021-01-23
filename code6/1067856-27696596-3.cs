    private Task<string> DoSomethingWithThisEmployeee(string lastName, string firstName, CancellationToken ct)
    {
        TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
        Random rand = new Random();
        System.Threading.Timer t;
        t = new System.Threading.Timer(
            () =>
            {
                try
                {
                    t.Dispose();
                    tcs.ThrowIfCancellationRequested();
                    tcs.TrySetResult(lastName + " - " + firstName);
                }
                catch OperationCanceledException ex
                {
                }
                catch Exception ex
                {
                    tcs.TrySetException(ex);
                }
            },
            rand.Next(30000, 60000),
            Timeout.Infinite);
        return tcs.Task;
    }
