    var cancellation = new CancellationTokenSource();
    var listener = new TcpListener(IPAddress.Any, 5555);
    try
    {
        while (true)
        {
            var client = await Task.Run(
                () => listener.AcceptTcpClientAsync(),
                cancellation.Token);
            // use the client, pass CancellationToken to other blocking methods too
        }
    }
    finally
    {
        listener.Stop();
    }
    // somewhere in another thread
    cancellation.Cancel();
