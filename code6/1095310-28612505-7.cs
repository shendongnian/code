    try
    {
        var client = new TcpClient();
        using (client.CreateTimeoutScope(TimeSpan.FromSeconds(2)))
        {
            var result = await client.ConnectAsync();
            // Handle result
        }
    }
    catch (ObjectDisposedException)
    {
        return null;
    }
