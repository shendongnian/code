    UdpClient client = new UdpClient(0, AddressFamily.InterNetwork);
    byte[] datagram = Encoding.ASCII.GetBytes("hello world!");
    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Loopback, ((IPEndPoint)client.Client.LocalEndPoint).Port);
    client.Send(datagram, datagram.Length, ipEndPoint);
    datagram = client.Receive(ref ipEndPoint);
    Console.WriteLine("Received: \"" + Encoding.ASCII.GetString(datagram) + "\"");
