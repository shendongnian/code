    //If you know the size beforehand, set it as an int and compare
    // it to what you have so far
    int totalBytes = 9001;
            
    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
    {
        socket.Connect(e.IPAddress, e.Port);
        using (var fs = new FileStream(e.Filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
        {
            byte[] buffer = new byte[8192];
            int read;
            int bytesSoFar = 0; //Use this to keep track of how many bytes have been read
            do
            {
                read = socket.Receive(buffer);
                fs.Write(buffer, 0, read);
                bytesSoFar += read;
            } while (bytesSoFar < totalBytes);
        }
    }
