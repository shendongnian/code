    BlockingCollection<WorkItem> WorkItems = new BlockingCollection<WorkItem>();
    void WorkerThreadProc()
    {
        foreach (var item in WorkItems.GetConsumingEnumerable())
        {
            // process item
        }
    }
