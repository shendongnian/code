    // Setup
    double[] futureSeconds = { 1, 2.5, 3.7, 5, 9, 12.2, 15 };
    BlockingCollection<DateTime> queue = new BlockingCollection<DateTime>();
    Task task = ProcessSchedule(queue.GetConsumingEnumerable());
    // This would be equivalent to whatever process you have generating
    // the DateTime-based events (e.g. reading from a database)
    DateTime startTime = DateTime.UtcNow;
    foreach (DateTime eventTime in futureSeconds.Select(s => startTime + TimeSpan.FromSeconds(s)))
    {
        queue.Add(eventTime);
    }
    // Don't call this until you want processing to stop
    queue.CompleteAdding();
    task.Wait();
