    ConcurrentDictionary<UniqueId, TaskCompletionSource<byte[]>> _dictionary;
    async Task Listen(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            using (var ns = new NetworkStream(_socket))
            {
                byte[] responseBuffer = await ReceiveMessageAsync(ns);
                var id = ExtractId(responseBuffer);
                TaskCompletionSource<byte[]> tcs;
                if (dictionary.TryRemove(id, out tcs))
                {
                    tcs.SetResult(responseBuffer);
                }
                else
                {
                    // error
                }
            }
        }
    }
    
    Task RegisterTask(UniqueId id)
    {
        var tcs = new TaskCompletionSource<byte[]>();
        if (!_dictionary.TryAdd(id, tcs))
        {
            // error
        }
        return tcs.Task;
    }
