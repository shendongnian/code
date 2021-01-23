    public void Send(byte[] msg)
    {
        var header = BitConverter.GetBytes(msg.Length);
        socket.Send(header, 0, header.Length);
        socket.Send(msg, 0, msg.Length);
    }
