    using (Session session = new Session())
    {
        // Will continuously report progress of transfer
        session.FileTransferProgress += SessionFileTransferProgress;
        
        /* Down / upload code here */
    }
    void SessionFileTransferProgress(object sender, FileTransferProgressEventArgs e)
    {
        // Print transfer progress
        Console.Write("\r{0} ({1:P0})", e.FileName, e.FileProgress);
    }
