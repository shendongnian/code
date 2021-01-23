    AsyncProducerConsumerQueue<byte[]> _queue;
    Stream _stream;
    // producer
    async Task ReceiveAsync(CancellationToken token)
    {
        while (true)
        {
           var list = new List<byte>();
           while (true)
           {
               token.ThrowIfCancellationRequested(token);
               var packet = await _device.ReadAsync(token);
               list.Add(packet);
               if (list.Count == 1000)
                   break;
           }
           // push next batch
           await _queue.EnqueueAsync(list.ToArray(), token);
        }
    }
    // consumer
    async Task LogAsync(CancellationToken token)
    {
        Task previousFlush = Task.FromResult(0); 
        CancellationTokenSource cts = null;
        while (true)
        {
           token.ThrowIfCancellationRequested(token);
           // get next batch
           var nextBatch = await _queue.DequeueAsync(token);
           if (!previousFlush.IsCompleted)
           {
               cts.Cancel(); // cancel the previous flush if not ready
               throw new Exception("failed to flush on time.");
           }
           await previousFlush; // it's completed, observe for any errors
           // start flushing
           cts = CancellationTokenSource.CreateLinkedTokenSource(token);
           previousFlush = _stream.WriteAsync(nextBatch, 0, nextBatch.Count, cts.Token);
        }
    }
