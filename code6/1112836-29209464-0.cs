    public async Task<IQueueMessage> ReceiveAsycn(TimeSpan serverWaitTime)
            {
                var task = QueueClient
                                          .ReceiveAsync(serverWaitTime)
                                          .ContinueWith(bm => bm.Result==null ? null : new QueueMessage { Message=bm.Result});
                return await task;
            }
