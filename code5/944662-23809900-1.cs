    public void Foo()
    {
        var cts = new CancellationTokenSource();
        var thread = new Thread(() => DoWork(cts.Token));
        FormClosing += (s, args) =>
        {
            cts.Cancel();
            thread.Join();
        };
        thread.Start();
    }
    private void DoWork(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            //Do some  work
        }
    }
