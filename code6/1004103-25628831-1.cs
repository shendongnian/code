    private static Task ProcessJobs(CancellationToken cancellationToken)
    {
        var block = new ActionBlock<Job>(
            job => job.Process(),
            new ExecutionDataflowBlockOptions
            {
                BoundedCapacity = 50,
                CancellationToken = cancellationToken
            });
        var producer = Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var job in await GetJobsAsync())
                {
                    await block.SendAsync(job, cancellationToken);
                }
            }
        });
        return Task.WhenAll(producer, block.Completion);
    }
