    public static void Get_Or_Put_Files(string source, string dest, bool isFilesAreGetting)
    {
        using (Session session = new Session())
        {
            session.Open(sessionOptions);
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;
            TransferOperationResult transferResult;
            if(isFilesAreGetting)
            {
                transferResult = session.GetFiles(source, dest, false, transferOptions);
            }
            else
            {
                transferResult = session.PutFiles(source, dest, false, transferOptions);
            }
            transferResult.Check();
            foreach (TransferEventArgs transfer in transferResult.Transfers)
            {
                Console.WriteLine("Transfer file from {0} to {1}", source, dest);
            }
        }
    }
