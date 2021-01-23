    string ServersToPing = "localhost:80 localhost:443";
    string[] ServerArrays = ServersToPing.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
    foreach (string server in ServerArrays)
    {
        string host = server.Substring(0, server.IndexOf(':'));
        Ping pingreq = new Ping();
        PingReply pingrep = pingreq.Send(host, 30 * 1000);
        Console.WriteLine("{0}:time={1}ms", pingrep.Address.ToString(), pingrep.RoundtripTime.ToString());
    }
    
    Console.ReadLine();
