    var block = new ActionBlock<int>(
        i =>
        {
            Console.WriteLine("Calculating {0}²", i);
            Console.WriteLine("x² = {0}", (int)Math.Pow(i, 2));
        },
        new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = 8});
    foreach (var number in Enumerable.Range(1, 1000))
    {
        block.Post(number);
    }
    block.Complete();
    block.Completion.Wait();
