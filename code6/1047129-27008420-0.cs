    if (!File.Exists(FlagFilePath) && !IsDownloadInProgress)
    {
        // building session
        
        sessionOptions.FileTransferred += OnFileTransferComplete;
        IsDownloadInProgress = true;
    }
        
    private static void OnFileTransferComplete(object sender, TransferEventArgs e)
    {
         IsDownloadInProgress = false;
        ((Session)sender).FileTransferred -= OnFileTransferComplete
    }
