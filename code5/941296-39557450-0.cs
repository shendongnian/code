    #region ----------------File System WATCHER ----------------------------
    // this happens at construction time
    FileSystemWatcher fileSystemWatcher = new System.IO.FileSystemWatcher();
    fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(fileSystemWatcher_Changed);
    fileSystemWatcher.Deleted += new System.IO.FileSystemEventHandler(fileSystemWatcher_Deleted);
    fileSystemWatcher.Renamed += new System.IO.RenamedEventHandler(fileSystemWatcher_Renamed);
 
    private void WatchFile(String fullFilePath)
    {
        if (!File.Exists(fullFilePath))
            return;
        fileSystemWatcher.Path = Path.GetDirectoryName(fullFilePath);
        fileSystemWatcher.Filter = Path.GetFileName(fullFilePath);
        fileSystemWatcher.EnableRaisingEvents = true;
    }
    //    and those are the handlers
    //
    private void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
    {
        Bitmap bmp = null;
        FileInfo finfo = new FileInfo(m_currentFileName);
        if (!finfo.Exists)
            return;
        //Load and display the bitmap saved inside the text file/
        ------------ here ---------------
        // OR WHATEVER YOU NEED TO
        
    }
    private void fileSystemWatcher_Deleted(object sender, System.IO.FileSystemEventArgs e)
    {
        this.pictureBoxArea.BackgroundImage = null;
        fileSystemWatcher.EnableRaisingEvents = false;
        labelFileInfo.Text = "";
        MediaAvailablForUpload = false;
    }
    private void fileSystemWatcher_Renamed(object sender, System.IO.RenamedEventArgs e)
    {
        pictureBoxArea.BackgroundImage = null;
        fileSystemWatcher.EnableRaisingEvents = false;
        labelFileInfo.Text = "";
    }
    #endregion
