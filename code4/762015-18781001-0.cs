    const int MaxFileSize = 10 * 1024 * 1024;
    private void Example()
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect("localhost", 12345);
        StartReading(socket);
    }
    private void StartReading(Socket socket)
    {
        // read the length of the data (header)
        EasySocketReader.ReadFromSocket(socket, 4, (filenameLengthData) =>
        {
            // parse the length of the filename
            int filenameLength = BitConverter.ToInt32(filenameLengthData.Array, filenameLengthData.Offset);
            // read the data
            EasySocketReader.ReadFromSocket(socket, filenameLength, (filenameData) =>
            {
                // parse the filename
                string filename = Encoding.UTF8.GetString(filenameData.Array, filenameData.Offset, filenameData.Count);
                EasySocketReader.ReadFromSocket(socket, 4, (fileLengthData) =>
                {
                    // parse the length of the data
                    int fileLength = BitConverter.ToInt32(fileLengthData.Array, fileLengthData.Offset);
                    if (fileLength > MaxFileSize)
                    {
                        Trace.WriteLine("Failed receiving file :" + filename + " with size " + fileLength + ", file too big");
                        socket.Close();
                        return;
                    }
                    Trace.WriteLine("Receiving file :" + filename + " with size " + fileLength);
                    // read the data
                    EasySocketReader.ReadFromSocket(socket, fileLength, (fileData) =>
                    {
                        Trace.WriteLine("Writing file :" + filename);
                            
                        // write to the file
                        using (FileStream stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
                            stream.Write(fileData.Array, fileData.Offset, fileData.Count);
                        StartReading(socket);
                    });
                });
                StartReading(socket);
            });
        });
    }
