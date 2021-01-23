    static void Main(string[] args)
    {
        string IP = "127.0.0.1"
        Task.Factory.StartNew(th1T, IP);
    } 
    static void th1T(object value)
    {
        // The value parameter will contain the IP here
        string ip = (string)value;
        while (true)
        {
            var ping = new Ping();
            ping.Send(ip);
        }
    }
