    private static Task ProcessJobsAsync(CancellationToken cancellationToken)
    {
        var block = new ActionBlock<Job>(
            job => job.Process(),
            new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount, // Or any other value that fits
                BoundedCapacity = 50,
            });
        cancellationToken.Register(block.Complete);
        var producer = Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var job in await GetJobsAsync())
                {
                    await block.SendAsync(job,cancellationToken);
                }
            }
        });
        return Task.WhenAll(producer, block.Completion);
    }
