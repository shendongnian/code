    Task AsyncLoop(CancellationToken cancellationToken)
    {
        using (RedisConnection redis = new RedisConnection("localhost"))
        {
            var queue = "my_queue";
            var reserved = string.Concat(queue, "_reserved");
            redis.Open();
            while (true)
            {
                // observe cancellation requests
                cancellationToken.ThrowIfCancellationRequested();
                var pushRequestTask = redis.Lists.RemoveLastAndAddFirstString(0, queue, reserved);
                // continue on a random thread after await, 
                // thanks to ConfigureAwait(false)
                var pushRequest = await pushRequestTask.ConfigureAwait(false);
                // process pushRequest
            }
        }
    }
    void Loop(CancellationToken cancellationToken)
    {
        try
        {
            AsyncLoop().Wait();
        }
        catch (Exception ex)
        {
            while (ex is AggregateException && ex.InnerException != null)
                ex = ex.InnerException;
            // might be: await Console.Error.WriteLineAsync(ex.Message),
            // but you cannot use await inside catch, so: 
            Console.Error.WriteLine(ex.Message);
        }
    }
