    private System.IO.FileSystemWatcher fsw;
    fsw = new System.IO.FileSystemWatcher();
    fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                                 | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    
    fsw.Changed += new FileSystemEventHandler(OnChanged);
    fsw.Created += new FileSystemEventHandler(OnChanged);
    fsw.Deleted += new FileSystemEventHandler(OnChanged);
    fsw.Renamed += new RenamedEventHandler(OnRenamed);
                            
    fsw.EnableRaisingEvents = true;
