    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "example.com",
        UserName = "username",
        Password = "password",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Get list of files in the directory
        string remotePath = "/remote/path/";
        RemoteDirectoryInfo directoryInfo = session.ListDirectory(remotePath);
        foreach (RemoteFileInfo fileInfo in directoryInfo.Files)
        {
            Console.WriteLine("{0} {1}", fileInfo.Name, fileInfo.LastWriteTime);
        }    
    }
