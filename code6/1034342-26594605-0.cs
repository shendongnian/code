    var block = new ActionBlock<int>(
        _ => Task.Delay(-1),
        new ExecutionDataflowBlockOptions
        {
            BoundedCapacity = 1000,
            MaxDegreeOfParallelism = 10,
        });
    for (int i = 0; i < 1001; i++)
    {
        Console.WriteLine("#{0} - InputCount={1}", i, block.InputCount);
        await block.SendAsync(i);
    }
