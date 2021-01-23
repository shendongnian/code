    public static class Extensions
    {
      /// <summary>
      /// Obtain the current state of the socket underpinning a TcpClient.
      /// Unlike TcpClient.Connected this is reliable and does not require 
      /// capture of an exception resulting from a failed socket write.
      /// </summary>
      /// <param name="tcpClient">TcpClient instance</param>
      /// <returns>Current state of the TcpClient.Client socket</returns>
      public static TcpState GetState(this TcpClient tcpClient)
      {
        var foo = IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections()
          .SingleOrDefault(x => x.LocalEndPoint.Equals(tcpClient.Client.LocalEndPoint));
        return foo != null ? foo.State : TcpState.Unknown;
      }
    }
