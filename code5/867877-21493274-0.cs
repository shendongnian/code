    using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
    {
        socket.Connect(e.IPAddress, e.Port);
        using (var fs = new FileStream(e.Filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
        {
            byte[] buffer = new byte[8192];
            int read;
            while (socket.Available > 0) //Just changed this line...
            {
                read = socket.Receive(buffer); //...and this one
                fs.Write(buffer, 0, read);
            }
        }
    }
