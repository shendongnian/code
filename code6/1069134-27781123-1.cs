    TcpClient client = new TcpClient("chat.freenode.net", 6667);
    StreamReader reader = new StreamReader(client.GetStream());
    StreamWriter writer = new StreamWriter(client.GetStream());
    string recievedData = reader.ReadLine();
    writer.WriteLine("NICK IKESBOT");
    writer.Flush();
