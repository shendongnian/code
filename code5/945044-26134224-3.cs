    void ProcessUrls()
    {
        foreach (var uri in UrlQueue.GetConsumingEnumerable())
        {
            // Wait for an available client
            var client = Clients.Take();
            // and make an asynchronous request
            client.DownloadDataAsync(uri, client);
        }
        // When the queue is empty, you need to wait for all of the
        // clients to complete their requests.
        // You know they're all done when you dequeue all of them.
        for (int i = 0; i < MaxRequests; ++i)
        {
            var client = Clients.Take();
            client.Dispose();
        }
    }
