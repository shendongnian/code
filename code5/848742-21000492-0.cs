    private static FileSystemWatcher watcher;
    public static void Run()
    {
    watcher = new FileSystemWatcher();
    ...
    GC.KeepAlive(watcher);  
    }
