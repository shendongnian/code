    watcher.Changed += new FileSystemEventHandler(OnChanged);
    watcher.Created += new FileSystemEventHandler(OnCreated);
    watcher.Deleted += new FileSystemEventHandler(OnDeleted);
    private void OnCreated(object source, FileSystemEventArgs e)
    {
        // do something when the watcher is created
    }
    private void OnDeleted(object source, FileSystemEventArgs e)
    {
        // do something when the watcher is deleted
    }
