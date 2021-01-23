    const int MaxRequests = 15;
    BlockingCollection<WebClient> Clients = new BlockingCollection<WebClient>();
    // start a single consumer thread
    var ProcessingThread = Task.Factory.StartNew(() => ProcessUrls, TaskCreationOptions.LongRunning);
    // Create the WebClient objects and add them to the queue
    for (var i = 0; i < MaxRequests; ++i)
    {
        var client = new WebClient();
        // Add an event handler for the DownloadDataCompleted event
        client.DownloadDataCompleted += DownloadDataCompletedHandler;
        // And add this client to the queue
        Clients.Add(client);
    }
    // add the code from above that reads the file and populates the queue
