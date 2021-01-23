    private static void Main()
    {
        var block = new ActionBlock<Job>(
            async job => await job.ProcessAsync(),
            new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 5});
        for (var i = 0; i < 50; i++)
        {
            block.Post(new Job());
        }
        Console.ReadKey();
    }
