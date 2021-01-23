    public static class SocketReader
    {
        public static void ReadFromSocket(Socket socket, int count, Action<byte[]> endRead)
        {
            // read from socket, construct a new buffer.
            DoReadFromSocket(socket, 0, count, new byte[count], endRead);
        }
        public static void ReadFromSocket(Socket socket, int count, ref byte[] buffer, Action<byte[]> endRead)
        {
            // if you do have a buffer available, you can pass that one. (this way you do not construct new buffers for receiving.
            // the ref is because if the buffer is too small, it will return the newly created buffer.
            // if the buffer is too small, create a new one.
            if (buffer.Length < count)
                buffer = new byte[count];
            DoReadFromSocket(socket, 0, count, buffer, endRead);
        }
        // This method will continues read until count bytes are read. (or socket is closed)
        private static void DoReadFromSocket(Socket socket, int bytesRead, int count, byte[] buffer, Action<byte[]> endRead)
        {
            // Start a BeginReceive.
            socket.BeginReceive(buffer, bytesRead, count - bytesRead, SocketFlags.None, (result) =>
            {
                // Get the bytes read.
                int read = socket.EndReceive(result);
                // if zero bytes received, the socket isn't available anymore.
                if (read == 0)
                {
                    endRead(new byte[0]);
                    return;
                }
                // increase the bytesRead, (index point for the buffer)
                bytesRead += read;
                // if all bytes are read, call the endRead with the buffer.
                if (bytesRead == count)
                    endRead(buffer);
                else
                    // if not all bytes received, start another BeginReceive.
                    DoReadFromSocket(socket, bytesRead, count, buffer, endRead);
            }, null);
        }
    }
