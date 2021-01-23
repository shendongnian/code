    using (var client = new UdpClient())
    using (var cts = CancellationTokenSource.CreateLinkedTokenSource(userToken))
    {
        UdpClient.Client.ReceiveTimeout = 2000;
        cts.CancelAfter(2000);
        var result = await client.ReceiveAsync().WithCancellation(cts.Token);
        // ...
    }
