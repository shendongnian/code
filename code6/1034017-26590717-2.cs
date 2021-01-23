    static void Main(string[] args)
    {
        TcpListener listener = new TcpListener(IPAddress.Loopback, 25);
        listener.Start();
        using (SMTPServer handler = new SMTPServer(listener.AcceptTcpClient()))
        {
            while (true)
            {
                Thread thread = new System.Threading.Thread(new ThreadStart(handler.Run));
                thread.Start();
            }
        }
    }
