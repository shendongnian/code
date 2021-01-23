    watcher.Path = directory name;
    watcher.NotifyFilter = NotifyFilters.LastWrite;
    watcher.Filter = "*.xls";
    watcher.Changed += OnDirectoryChange;
    watcher.Error += OnError;
    watcher.EnableRaisingEvents = true;
    // Watch only files not subdirectories.
    watcher.IncludeSubdirectories = false;
