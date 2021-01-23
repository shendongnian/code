    await socket.ConnectTaskAsync(host,port);
    connectedLabel.Content = "Connected";
----
    public static class SocketExtensions
    {
        public static Task ConnectTaskAsync(this Socket socket, string host, int port)
        {
            return Task.Factory.FromAsync(
                             socket.BeginConnect(host, port, null, null),
                             socket.EndConnect);
        }
    }
