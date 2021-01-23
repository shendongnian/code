    static bool checkHost(string host,int timeout)
    {
        if (!host.Contains(':')) 
            return false;
        try
        {
            string[] h = host.Split(':');
            Task e = new TcpClient().ConnectAsync(h[0], int.Parse(h[1]));
            new Task(e.Start);
            Thread.Sleep(timeout);
            return e.IsCompleted;
        }
        catch (SocketException){ }
        catch (ArgumentOutOfRangeException) { }
        return false;
    }
