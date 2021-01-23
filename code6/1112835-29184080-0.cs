    public Task<IQueueMessage> ReceiveAsync(TimeSpan serverWaitTime)
    {
        Task<QueueMessage> task = QueueClient
                                  .ReceiveAsync(serverWaitTime)
                                  .ContinueWith(bm => new QueueMessage{Message = bm});
        return task;
    }
