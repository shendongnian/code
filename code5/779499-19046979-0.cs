    while (true)
    {
        try
        {
            TcpClient client = new TcpClient(ip, port);
            if (client.Connected)
            {
                // do something
                client.close();
            }
        }
        catch (SocketException) { }
        Thread.Sleep(millisecs);
    }
