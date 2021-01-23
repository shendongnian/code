    public void Go()
    {
        const int MAX_DEGREE_PARALLELISM = 4;
        using (var semaphore = new SemaphoreSlim(MAX_DEGREE_PARALLELISM, MAX_DEGREE_PARALLELISM))
        {
            List<WorkData> unfinishedWork = WorkData.LoadUnfinishedWork();
            IEnumerable<WorkData> work = unfinishedWork
                .Concat(FetchQueuedWork())
                .Select(w =>
                {
                    // Side-effect: bad practice, but easier
                    // than writing your own IEnumerable.
                    semaphore.Wait();
                    return w;
                });
            // You still need to specify MaxDegreeOfParallelism
            // here so as not to saturate your thread pool when
            // Parallel.ForEach's load balancer kicks in.
            Parallel.ForEach(work, new ParallelOptions { MaxDegreeOfParallelism = MAX_DEGREE_PARALLELISM }, workUnit =>
            {
                try
                {
                    this.DoWork(workUnit);
                }
                finally
                {
                    semaphore.Release();
                }
            });
        }
    }
