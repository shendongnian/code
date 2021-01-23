    void StartReceiving()
    {
      // Start receiving asynchronously...
      socket.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, OnDataReceived, null);
    }
    
    void OnDataReceived(IAsyncResult result)
    {
      // Finish receiving this data.
      var numberOfBytesReceived = socket.EndReceive(result);
      
      // Start receiving asynchronously again...
      if(numberOfBytesReceived > 0 && socket.Connected)
        socket.BeginReceive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, OnDataReceived, null);
    }
