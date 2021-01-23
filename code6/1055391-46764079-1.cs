    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "ftp.example.com",
        UserName = "username",
        Password = "password",
    };
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Download today's times
        TransferOptions transferOptions = new TransferOptions();
        transferOptions.FileMask = "*>=" + DateTime.Today.ToString("yyyy-MM-dd");
        session.GetFiles("/remote/path/*", @"C:\local\path\", false, transferOptions).Check();
    }
