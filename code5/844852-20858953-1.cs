    static void th1T()
    {
        while (true)
        {
            var ping = new Ping();
            ping.Send(Values.IP);
        }
    }
