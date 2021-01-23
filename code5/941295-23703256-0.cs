    static void StartWatching(string path)
    {
    	var watcher = new FileSystemWatcher();
    	watcher.Path = path;
    	watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName |
    						   NotifyFilters.DirectoryName;
    	watcher.Changed += watcher_Created;
    	watcher.Created += watcher_Created;
    	watcher.EnableRaisingEvents = true;
    
    	var copier = new Thread(ConsumeOutOfTheFilesToCopyQueue);
    	copier.Start();
    }
        static void watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (e.Name.Contains("whatever.dll"))
                if (!_filesToCopy.Contains(e.FullPath))
                    lock (_syncRoot)
                        if (!_filesToCopy.Contains(e.FullPath))
                            _filesToCopy.Enqueue(e.FullPath);
        }
