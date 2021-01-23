    const int MaxFileSize = 10 * 1024 * 1024;
    private void Example()
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect("localhost", 12345);
        StartReading(socket);
    }
    private void StartReading(Socket socket)
    {
        ReadPacket(socket, (filenameData) =>
        {
            if (filenameData.Count == 0)
            {
                // disconnected
                return;
            }
            // parse the filename
            string filename = Encoding.UTF8.GetString(filenameData.Array, filenameData.Offset, filenameData.Count);
            Trace.WriteLine("Receiving file :" + filename);
            ReadPacket(socket, (fileData) =>
            {
                if (fileData.Count == 0)
                {
                    // disconnected
                    return;
                }
                Trace.WriteLine("Writing file :" + filename);
                // write to the file
                using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    stream.Write(fileData.Array, fileData.Offset, fileData.Count);
                // start waiting for another packet.
                StartReading(socket);
            });
        });
    }
    private void ReadPacket(Socket socket, Action<ArraySegment<byte>> endRead)
    {
        // read header. KEY + (length of data) (8 bytes)
        EasySocketReader.ReadFromSocket(socket, 4, (headerBufferSegment) =>
        {
            // if the ReadFromSocket returns 0, the socket is closed.
            if (headerBufferSegment.Count == 0)
            {
                // disconnected;
                endRead(new ArraySegment<byte>());
                return;
            }
            // Get the length of the data that follows
            int length = BitConverter.ToInt32(headerBufferSegment.Array, headerBufferSegment.Offset);
            // Check the length
            if (length > MaxFileSize)
            {
                // disconnect
                endRead(new ArraySegment<byte>());
                return;
            }
            // Read bytes specified in length.
            EasySocketReader.ReadFromSocket(socket, length, (dataBufferSegment) =>
            {
                // if the ReadFromSocket returns 0, the socket is closed.
                if (dataBufferSegment.Count == 0)
                {
                    endRead(new ArraySegment<byte>());
                    return;
                }
                endRead(dataBufferSegment);
            });
        });
    }
