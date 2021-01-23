    FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(@"E:\TestDir");
    fileSystemWatcher.Changed += OnChanged;
    fileSystemWatcher.Created += OnChanged;
    fileSystemWatcher.Deleted += OnChanged;
    fileSystemWatcher.Renamed += OnChanged;
    fileSystemWatcher.EnableRaisingEvents = true;
