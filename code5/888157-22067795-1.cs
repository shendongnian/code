    try
    {
        data = new byte[1024];
        int recv = sock.Receive(data);
        stringData = Encoding.ASCII.GetString(data, 0, recv);
    }
    catch(SocketException ex)
    {
        if (ex.SocketErrorCode != SocketError.TimedOut)
            throw;
        // In case of Timeout, do nothing, continue loop
    }
