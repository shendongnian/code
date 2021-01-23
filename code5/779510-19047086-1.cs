    byte[] buffer = new byte[count];
    socket.BeginReceive(buffer, 0, count, SocketFlags.None, (asyncResult) =>
    {
        int bytesRead = socket.EndReceive(asyncResult);
        if(bytesRead == 0)
        {
            // disconnected.
        }
    }
