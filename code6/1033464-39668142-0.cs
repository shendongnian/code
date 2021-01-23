    private int totalFiles;
    private int filesExtracted;
    
    /*...*/
    
    using (ZipFile zip = ZipFile.Read(ROBOT_INSTALL_SPECIAL))
    {
        totalFiles = zip.Count;
        filesExtracted = 0;
        zip.ExtractProgress += ZipExtractProgress; 
        zip.ExtractAll(ROBOT0007, ExtractExistingFileAction.OverwriteSilently);
    }
    
    /*...*/
    
    private void ZipExtractProgress(object sender, ExtractProgressEventArgs e)
    {
        if (e.EventType != ZipProgressEventType.Extracting_BeforeExtractEntry)
            return;
        filesExtracted++;
        progressBar.Value = 100 * filesExtracted / totalFiles;
    }
