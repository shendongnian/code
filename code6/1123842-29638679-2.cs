    // Create a FileSystemWatcher property.
    FileSystemWatcher fsw { get; set; }
    // So we can set the FileToWatch within WatchFilesBeforeTransfer().
    private string FileToWatch { get; set; }
    private void WatchFilesBeforeTransfer(string FileName, string DestinationFolder)
    {
        fsw = new FileSystemWatcher();
        fsw.Path = DestinationFolder;
        FileToWatch = FileName;
        // Only if you need support for multiple directories. Code example note included.
        fsw.InclueSubdirectories = true; 
        // We'll be searching for the file name and directory.
        fsw.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName 
        // If it's simply moving the file to another location on the computer.
        fsw.Renamed += new RenamedEventHandler(FileRenamed); 
        // If it's going to another device/computer. 
        fsw.Created += new FileSystemEventHandler(FileCreated);
        fsw.EnableRaisingEvents = true;
    }
    // If the file is just renamed. (Move/Rename)
    private void FileRenamed(Object source, FileSystemEventArgs e)
    {
        // Do something.
        // Note that the full filename is accessed by e.FullPath.
        if (e.Name == FileToWatch) 
        {
             DisplaySuccessfulMessage(e.Name);
             KillFileWatcher();
        }
    }
    // If creating a new file on another computer/device. (Copied)
    private void FileCreated(Object source, FileSystemEventArgs e)
    {
        // Do something.
        // Note that the full filename is accessed by e.FullPath.
        if (e.Name == FileToWatch) 
        {
             DisplaySuccessfulMessage(e.Name);
             KillFileWatcher();
        }
    }
    private void KillFileWatcher()
    {
       fsw.Dispose();
    }
