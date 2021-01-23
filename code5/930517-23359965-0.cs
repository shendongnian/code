    public async Task<Tuple<IPAddress, bool>> GetResponse(IPAddress address)
    {
      using (var client = new TcpClient(AddressFamily.InterNetwork))
      {
        var connectTask = client.ConnectAsync(address, 80);
        
        await Task.WhenAny(connectTask, Task.Delay(5000));
        
        if (connectTask.IsCompleted)
            return Tuple.Create(address, true);
        else
            return Tuple.Create(address, false);
      }
    }
