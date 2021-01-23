    static string IP = "127.0.0.1"
    static void Main(string[] args)
    {
        // do some work and start th1T()
    }
    static void th1T()
    {
        while (true)
        {
            var ping = new Ping();
            ping.Send(IP);
        }
    }
