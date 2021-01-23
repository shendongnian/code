    FileSystemWatcher fsw { get; set; }
    private void WatchFilesBeforeTransfer(string folder)
    {
        fsw = new FileSystemWatcher();
        fsw.Path = folder;
        // Only if you need it.
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
        // Do something
    }
    // If creating a new file on another computer/device. (Copied)
    private void FileCreated(Object source, FileSystemEventArgs e)
    {
       // Do something. 
    }
    private void KillFileWatcher()
    {
       fsw.Dispose();
    }
