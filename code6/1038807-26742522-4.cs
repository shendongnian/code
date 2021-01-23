    // This is added.
    private readonly int _maxConcurrency;
    private readonly Semaphore _semaphore;
    internal bool TryLock()
    {
        return _semaphore.WaitOne(0);
    }
    internal void Release()
    {
        _semaphore.Release();
        _pool.NotifyNewWorkItem();
    }
    /// <summary>Initializes the queue.</summary>
    /// <param name="priority">The priority associated with this queue.</param>
    /// <param name="maxConcurrency">Max concurrency for this scheduler.</param>
    /// <param name="pool">The scheduler with which this queue is associated.</param>
    internal QueuedTaskSchedulerQueue(int priority, int maxConcurrency, QueuedTaskScheduler pool)
    {
        _priority = priority;
        _pool = pool;
        _workItems = new Queue<Task>();
        // This is added.
        _maxConcurrency = maxConcurrency;
        _semaphore = new Semaphore(_maxConcurrency, _maxConcurrency);
    }
