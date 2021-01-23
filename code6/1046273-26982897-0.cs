    BlockingCollection<int> consumeFrom = new BlockingCollection<int>();
    int producerCount = 3;
    for (int i = 0; i < producerCount; i++)
    {
        int taskValue = i;
        // Make dummy task for example
        Task.Run(() =>
        {
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(1000);
                consumeFrom.Add(taskValue * 10 + j);
            }
            if (Interlocked.Decrement(ref producerCount) == 0)
            {
                consumeFrom.CompleteAdding();
            }
        });
    }
    foreach (int i in consumeFrom.GetConsumingEnumerable())
    {
        Console.WriteLine(i);
    }
