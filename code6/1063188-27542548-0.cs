    public Task Upload(string message)
    {
        using (var wc = new WebClient())
        {
            wc.UploadString(uri, message);
            // vs.
            await wc.UploadStringTaskAsync(uri, message);
        }
    }
    await Task.WhenAll(message.Select(message => Upload(message))) // multiple operations. 0 blocked threads.
    
