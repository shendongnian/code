    Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    // read header. (length of data) (4 bytes)
    SocketReader.ReadFromSocket(socket, 4, (headerBuffer) =>
        {
            if (headerBuffer.Length == 0)
            {
                // disconnected;
                return;
            }
            int length = BitConverter.ToInt32(headerBuffer, 0);
            // read bytes specified in length.
            SocketReader.ReadFromSocket(socket, length, (dataBuffer) =>
                {
                    if (dataBuffer.Length == 0)
                    {
                        // disconnected;
                        return;
                    }
                    // if you want this in a stream, you can do: This way the stream is readonly and only wraps arround the bytearray.
                    using (MemoryStream stream = new MemoryStream(dataBuffer, 0, length))
                    using (StreamReader reader = new StreamReader(stream))
                        while (!reader.EndOfStream)
                            Debug.WriteLine(reader.ReadLine());
                });
        });
