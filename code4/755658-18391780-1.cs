    public TcpClient() : this(AddressFamily.InterNetwork)
    {
        if (Logging.On)
        {
            Logging.Enter(Logging.Sockets, this, "TcpClient", (string) null);
        }
        if (Logging.On)
        {
            Logging.Exit(Logging.Sockets, this, "TcpClient", (string) null);
        }
    }
