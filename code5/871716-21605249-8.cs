    private static void Main(string[] args)
    {
        var listener = new TcpListener(IPAddress.Any, 12873);
        listener.Start();
        var listenTask = listener.AcceptTcpClientAsync();
        listenTask.ContinueWith((Task<TcpClient> t) =>
        {
            var client = t.Result;
            var stream = client.GetStream();
            const string messageText = "Hello World!";                
            var body = Encoding.UTF8.GetBytes(messageText);                
            var header = BitConverter.GetBytes(
                IPAddress.HostToNetworkOrder(body.Length));
            for (int i = 0; i < 5; i++)
            {
                stream.Write(header, 0, 4);
                stream.Write(body, 0, 4);
                stream.Flush();
                // deliberate nasty delay
                Thread.Sleep(2000);
                stream.Write(body, 4, body.Length - 4);
                stream.Flush();
            }
            stream.Close();
            listener.Stop();
        });
        var tcpClient = new TcpClient();
        tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, 12873));
        var clientStream = tcpClient.GetStream();
        ReadMessages(clientStream).Subscribe(
            Console.WriteLine,
            ex => Console.WriteLine("Error: " + ex.Message),
            () => Console.WriteLine("Done!"));
        Console.ReadLine();
    }
