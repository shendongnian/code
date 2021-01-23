    private static void Main(string[] args)
    {
        var bufferBlock = new BufferBlock<int>();
        var actionBlock =
            new ActionBlock<int>(i => Console.WriteLine("Reading number {0} in thread {1}",
                                      i, Thread.CurrentThread.ManagedThreadId),
                                 new ExecutionDataflowBlockOptions 
                                     {MaxDegreeOfParallelism = 5});
        bufferBlock.LinkTo(actionBlock);
        Produce(bufferBlock);
        Console.ReadKey();
    }
    private static void Produce(BufferBlock<int> bufferBlock)
    {
        foreach (var num in Enumerable.Range(0, 500))
        {
            bufferBlock.Post(num);
        }
    }
