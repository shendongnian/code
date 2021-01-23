    TcpClient client = new TcpClient("myserver.net", 1234);
    var stream = new StreamReader(client.GetStream(),Encoding.ASCII);
    string line = null;
    while ((line = stream.ReadLine()) != null)
    {
        Console.WriteLine(line);
    }
