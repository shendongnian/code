    var buffer = new byte[100000];
    using (TcpClient tcp = new TcpClient(AddressFamily.InterNetwork)
    {
        Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    })
    {
        await tcp.ConnectAsync("host", 12345);
        if (tcp.Connected)
        {
            using (var stream = tcp.GetStream())
            {
                await stream.ReadAsync(buffer, 0, buffer.Length);
            }
        }
    }
    using (var fs = File.Create("1.jpg"))
    {
        await fs.WriteAsync(buffer, 0, buffer.Length);
    }
