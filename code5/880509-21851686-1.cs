    private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            WatcherChangeTypes watcherChangeTypes = e.ChangeType;
            string fullPath = e.FullPath;
            string name = e.Name;
        }
