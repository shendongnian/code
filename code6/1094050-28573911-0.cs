    private static void Main(string[] args)
    {
        // ...
        var cts = new CancellationTokenSource();
        Task producer = Produce(queue, cts.Token);
        Trace.TraceInformation("Starting to wait on producer and consumer...");
        try
        {
            await consumer.Completion;
        }
        catch
        {
            cts.Cancel();
            // handle
        }
        
        try
        {
            await producer
        }
        catch
        {
            // handle
        }
    }
    
    private static async Task Produce(BufferBlock<MyClass> queue, CancellationToken token)
    {
        for (int i = 0; i < 20; i++)
        {
            await queue.SendAsync(new MyClass(i), token);
            Trace.TraceInformation("Sending object number {0}", i);
            await Task.Delay(1);
        }
        Trace.TraceInformation("Completing the producer");
        queue.Complete();
    }
