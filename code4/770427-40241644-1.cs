    public void OnChanged(object source, FileSystemEventArgs e)
    {
        FileSystemWatcher watcher = null;
        try
        {
            watcher = (FileSystemWatcher)source;
            watcher.EnableRaisingEvents = false;
        }
        finally
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = true;
            }
        }
    }
