    Queue<DbWork> dbUpdates = new Queue<DbWork>();
    EventWaitHandle waiter = new EventWaitHandle(false, EventResetMode.ManualReset);
    ...
    // Init :
    new Thread(new ThreadStart(DbUpdateWorker));
    ...
    private void DbUpdateWorker()
    {
        while (true)
        {
            DbWork currentWork = null;
            lock (dbUpdates)
            {
                if (dbUpdates.Count > 0)
                    currentWork = dbUpdates.Dequeue();
            }
            if (currentWork != null)
            {
                currentWork.DoWork();
            }
            if (dbUpdates.Count == 0)
            {
                waiter.WaitOne();
            }
        }
    }
    public void AddWork(DbWork work)
    {
        lock (dbUpdates)
        {
            dbUpdates.Enqueue(work);
        }
        waiter.Set();
    }
