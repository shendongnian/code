    private static void ProcessThread1()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Adding data..");
            _samples.TryAdd(i, Timeout.Infinite, _cancellationTokenSource.Token);
            // not sure why the sleep is here
            Thread.Sleep(1000);
        }
        // Marks the queue as complete for adding.
        // When the queue goes empty, the consumer will know that
        // no more data is forthcoming.
        _samples.CompleteAdding();
    }
    private static void ProcessThread2()
    {
        int data;
        while (_samples.TryTake(out data, TimeSpan.Infinite, _cancellationTokenSource.Token))
        {
            // Do some work.    
            Console.WriteLine("Processing data..");
        }
        Console.WriteLine("Cancelled.");
    }
