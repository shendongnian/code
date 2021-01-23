    FileSystemWatcher watcher = new FileSystemWatcher();
    watcher.Path = " Live\Sites\User\297387\XYZ";
    watcher.Changed += new FileSystemEventHandler(OnChanged);
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
        // Specify what is done when a file is changed, created, or deleted.
       Console.WriteLine("File: " +  e.FullPath + " " + e.ChangeType);
    }
