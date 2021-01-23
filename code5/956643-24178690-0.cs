    public async Task<bool> LoginAsync(TcpClient client, ...)
    {
      var stream = client.GetStream();
    
      await stream.WriteAsync(...);
    
      // Make sure you read all that you need, and ideally no more. This is where
      // TCP can get very tricky...
      var bytesRead = await stream.ReadAsync(buf, ...);
    
      return CheckTheLoginResponse(buf);
    }
