    var producer = Task.Factory.StartNew(() =>
    {
        // Add 10 items to the queue
        foreach (var i in Enumerable.Range(0, 10))
            queue.Add(i);
        // Wait one minute
        Thread.Sleep(TimeSpan.FromMinutes(1.0));
        // Add 10 more items to the queue
        foreach (var i in Enumerable.Range(10, 10))
            queue.Add(i);
        // mark the queue as complete for adding
        queue.CompleteAdding();
    });
    // consumer
    foreach (var item in queue.GetConsumingEnumerable())
    {
        Console.WriteLine(item);
    }
