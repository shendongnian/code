    AsyncProducerConsumerQueue<Packet[]> _queue;
    // consumer
    async Task ReceiveAsync(CancellationToken token)
    {
        while (true)
        {
           var list = new List<Packet>();
           while (true)
           {
               token.ThrowIfCancellationRequested(token);
               var packet = await device.ReadAsync(token);
               list.Add(packet);
               if (list.Count == 1000)
                   break;
           }
           // push next batch
           await _queue.EnqueueAsync(list.ToArray(), token);
        }
    }
    // producer
    async Task LogAsync(CancellationToken token)
    {
        Task previousFlush = Task.FromResult(0); 
        var cts = new CancellationTokenSource();
        while (true)
        {
           token.ThrowIfCancellationRequested(token);
           // get next batch
           var nextBatch = _queue.DequeueAsync(token);
           var task == await Task.WhenAny(previousFlush, nextBatch);
           if (task != previousFlush && !previousFlush.IsCompleted)
           {
               cts.Cancel(); // cancel the previous flush
               // fail
               throw new Exception("The next batch is ready to soon.");
           }
           await previousFlush; // for errors
           await nextBatch; // for result
           cts = CancellationTokenSource.CreateLinkedTokenSource(token);
           previousFlush = WriteAsync(nextBatch.Result, cts.Token);
        }
    }
    async Task WriteAsync(Packet[] list, CancellationToken token)
    {
        // write the batch to a file asynchronously
        // ...
    }
