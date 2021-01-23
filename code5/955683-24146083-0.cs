    static int MAX_THREADS = 3;
    static SemaphoreSlim _Semaphore = new SemaphoreSlim(MAX_THREADS, MAX_THREADS);
    void ProcessRequest(Action action)
    {
        _Semaphore.Wait();
        Task.Run(action)
            .ContinueWith(t => _Semaphore.Release());
    }
