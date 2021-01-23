    int bytes_read = socket.Receive(state.Buffer, 0, StateObject.BUFFER_SIZE, SocketFlags.None);
    DateTime now = DateTime.UtcNow;
    
    if (bytes_read == 14)
    {
        if (state.Buffer.Count() > 13)
        {
            int packet = state.Buffer[13];
            InterpretRelevantByte(packet, now);
        }
    }
    else if (bytes_read > 14)
    {
        // maybe you received multiple messages in one packet
    }
    else
    {
        // maybe there is more data on the way
    }
