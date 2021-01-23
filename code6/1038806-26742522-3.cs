    /// <summary>Creates and activates a new scheduling queue for this scheduler.</summary>
    /// <returns>The newly created and activated queue at priority 0 and max concurrency of 1.</returns>
    public TaskScheduler ActivateNewQueue() { return ActivateNewQueue(0, 1); }
    /// <summary>Creates and activates a new scheduling queue for this scheduler.</summary>
    /// <param name="priority">The priority level for the new queue.</param>
    /// <returns>The newly created and activated queue at the specified priority.</returns>
    public TaskScheduler ActivateNewQueue(int priority, int maxConcurrency)
    {
        // Create the queue
        var createdQueue = new QueuedTaskSchedulerQueue(priority, maxConcurrency, this);
        
        ...
    }
