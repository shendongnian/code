    public void Foo()
    {
        var cts = new CancellationTokenSource();
        var task = Task.Run(() => DoWork(cts.Token));
        FormClosing += (s, args) =>
        {
            cts.Cancel();
            if (!task.IsCompleted)
            {
                args.Cancel = true;
                task.ContinueWith(t => Close());
            }
        };
    }
    private void DoWork(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            //Do some  work
        }
    }
