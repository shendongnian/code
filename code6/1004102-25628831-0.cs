    var block = new ActionBlock<Job>(
        job => job.Process(), 
        new ExecutionDataflowBlockOptions{BoundedCapacity = 50});
    Task.Run(async () =>
    {
        foreach (var job in GetJobs())
        {
            await block.SendAsync(job);
        }
        await Task.Delay(TimeSpan.FromMinutes(15));
    });
 
