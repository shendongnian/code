    public Task Loop(CancellationToken token)
    {
      using (UdpClient client = new UdpClient(80))
      {
        while (!token.IsCancellationRequested)
        {
          var data = await client.ReceiveAsync();
          // Process the data as needed
        }
      }
    }
