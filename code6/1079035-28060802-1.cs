    try 
    {
        CancellationTokenSource cts = new CancellationTokenSource(2000); // 2 seconds
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await
            client.SendRequestAsync(request).AsTask(cts.Token);
    }
    catch (TaskCanceledException ex)
    {
        // Catch operation aborted ...
    }
