    public static class SocketsExt
    {
        static public Task ReceiveDataAsync(
            this TcpClient tcpClient,
            byte[] buffer)
        {
            return Task.Factory.FromAsync(
                (asyncCallback, state) =>
                    tcpClient.Client.BeginReceive(buffer, 0, buffer.Length, 
                        SocketFlags.None, asyncCallback, state),
                (asyncResult) =>
                    tcpClient.Client.EndReceive(asyncResult), 
                null);
        }
    }
