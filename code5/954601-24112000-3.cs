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
        static public async Task<Int32> ReceiveInt32Async(
            this TcpClient tcpClient)
        {
            var data = new byte[sizeof(Int32)];
            await tcpClient.ReceiveDataAsync(data).ConfigureAwait(false);
            return BitConverter.ToInt32(data, 0);
        }
    }
