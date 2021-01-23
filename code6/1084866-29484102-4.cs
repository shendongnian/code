    using (var context = new Context())
    {
        var processedLog = new ProcessedLog
        {
            Location = new LogLocation()
        };
        var queuedLog = new QueuedLog
        {
            Location = new LogLocation()
        };
        context.ProcessedLogs.Add(processedLog);
        context.QueuedLogs.Add(queuedLog);
        context.SaveChanges();
    }
