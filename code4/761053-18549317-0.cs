    public static class SocketExtensions
    {
        public static Task<int> ReceiveTaskAsync(this Socket socket, byte[] buffer, int offset, int count)
        {
            return Task.Factory.FromAsync<int>(
                           socket.BeginReceive(buffer, offset, count, SocketFlags.None, null, socket),
                           socket.EndReceive);
        }
    }
