    private void HandleAsyncConnection(IAsyncResult result)
    {
      // Accept connection 
      TcpListener listener = (TcpListener)result.AsyncState;
      TcpClient client = listener.EndAcceptTcpClient(result);
      client.Client.GetSocketOption(SocketOptionLevel.IP, SocketOptionName.TypeOfService);
      ...
      // and then I do a redirect in HTTP
    }
