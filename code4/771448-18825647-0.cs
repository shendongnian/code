    CancellationTokenSource cts;
    private Task[] tasks;
    
    void Start()
    {
        cts = new CancellationTokenSource();
        tasks = new Task[1];
        tasks [0] = Task.Run(() => SomeWork(cts.Token), cts.Token);
    }
    
    void SomeWork(CancellationToken cancellationToken)
    {
        while (true)
        {
            // some work
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
    void Cancel()
    {
        cts.Cancel();
        Task.WaitAll(tasks);
    }
