    try
    {
        var client = new UdpClient();
        using (client.CreateTimeoutScope(TimeSpan.FromSeconds(2)))
        {
            var result = await client.ReceiveAsync();
            // Handle result
        }
    }
    catch (ObjectDisposedException)
    {
        return null;
    }
