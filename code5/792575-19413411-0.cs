    public void Close()
    {
        if (Socket.s_LoggingEnabled)
        {
            Logging.Enter(Logging.Sockets, this, "Close", null);
        }
        ((IDisposable)this).Dispose();
        if (Socket.s_LoggingEnabled)
        {
            Logging.Exit(Logging.Sockets, this, "Close", null);
        } 
    }
