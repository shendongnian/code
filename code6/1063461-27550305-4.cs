    public void monitorFolder(string folderPath)
    {
        System.IO.Directory.CreateDirectory(draft); // no need to check if exists
        if (monitor.ContainsKey(draft)) return; //if directory already being monitored
        m_Watcher = new System.IO.FileSystemWatcher();
        m_Watcher.Filter = "*.*";
        m_Watcher.Path = folderPath;  //here i tired giving && operator but not working
        m_Watcher.IncludeSubdirectories = true;
        m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
        m_Watcher.Created += new FileSystemEventHandler(OnChanged);
        m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
        m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
        m_Watcher.EnableRaisingEvents = true;
        monitor.Add(draft,m_Watcher); // add to monitor Container
    }
