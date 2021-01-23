    public void Foo()
    {
        var cts = new CancellationTokenSource();
        FormClosing += (s, args) => cts.Cancel();
        var thread = new Thread(() => DoWork(cts.Token));
        thread.Start();
    }
    private void DoWork(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            //Do some work
        }
    }
