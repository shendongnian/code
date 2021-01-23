    Dictionary<string, int> changeCounter = new Dictionary<string, int>();
    ...
    FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = @"C:\Path\To\Some\Folder";
    watcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.LastWrite;
    watcher.Created += OnCreated;
    watcher.Changed += OnChanged;
    
    ...
    private void OnCreated(object source, FileSystemEventArgs e)
    {
        changeCounter.Add(e.FullPath, 0);
    }
    private void OnChanged(object source, FileSystemEventArgs e)
    {
        if (changeCounter.ContainsKey(e.FullPath))
        {
            changeCounter[e.FullPath]++;
            if (changeCounter[e.FullPath] == 2) 
            {
                CopyFile(e.FullPath);
            }
        }
    }
