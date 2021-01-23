    Socket s = new Socket(SocketType.Stream, ProtocolType.Tcp);
    await s.ConnectTaskAsync("stackoverflow.com", 80);
    await s.SendTaskAsync(Encoding.UTF8.GetBytes("GET /\r\n\r\n"));
    var buf1 = await s.ReceiveExactTaskAsync(100); //read exactly 100 bytes
    Console.Write(Encoding.UTF8.GetString(buf1));
    var buf2 = await s.ReceiveExactTaskAsync(100); //read exactly 100 bytes
    Console.Write(Encoding.UTF8.GetString(buf2));
----
    public static class SocketExtensions
    {
        public static Task<int> ReceiveTaskAsync(this Socket socket, byte[] buffer, int offset, int count)
        {
            return Task.Factory.FromAsync<int>(
                             socket.BeginReceive(buffer, offset, count, SocketFlags.None, null, socket),
                             socket.EndReceive);
        }
        public static async Task<byte[]> ReceiveExactTaskAsync(this Socket socket, int len)
        {
            byte[] buf = new byte[len];
            int totalRead = 0;
            do{
                int read = await ReceiveTaskAsync(socket, buf, totalRead, buf.Length - totalRead);
                if (read <= 0) throw new SocketException();
                totalRead += read;
            }while (totalRead != buf.Length);
            return buf;
        }
        public static Task ConnectTaskAsync(this Socket socket, string host, int port)
        {
            return Task.Factory.FromAsync(
                             socket.BeginConnect(host, port, null, null),
                             socket.EndConnect);
        }
        public static Task SendTaskAsync(this Socket socket, byte[] buffer)
        {
            return Task.Factory.FromAsync<int>(
                             socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, null, socket),
                             socket.EndSend);
        }
    }
