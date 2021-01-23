    var server = new UDPServer(new[] { 10000, 10001, 10002 });
    await Task.Delay(2000); //Just to keep the code simple, for now.
    var udpClient = new UdpClient();
    udpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10001));
    while (true)
    {
        var line = Console.ReadLine();
        if (line == ".") break;
        var data = Encoding.UTF8.GetBytes(line);
        udpClient.Send(data, data.Length);
        IPEndPoint endPoint = null;
        var recvData = udpClient.Receive(ref endPoint);
        Console.WriteLine(Encoding.UTF8.GetString(recvData));
    }
