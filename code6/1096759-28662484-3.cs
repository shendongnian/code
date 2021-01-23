    var stream = new StreamReader(tcpClient.GetStream());
    string line = await stream.ReadLineAsync();
    while (line!=null)
    {
        //...
        line = await stream.ReadLineAsync();
    }
