    static void th1T(string IP)
    {
        while (true)
        {
            var ping = new Ping();
            ping.Send(IP);
        }
    }
