    private FileSystemWatcher watcher;
    private string debugPath;
    void Application_Start(object sender, EventArgs e)
    {
        string directoryPath = HttpContext.Current.Server.MapPath("/xmlFeed/");
        debugPath = HttpContext.Current.Server.MapPath("/debug.txt");
        watcher = new FileSystemWatcher();
        watcher.Path = directoryPath;
        watcher.Changed += somethingChanged;
        watcher.EnableRaisingEvents = true;
    }
    void somethingChanged(object sender, FileSystemEventArgs e)
    {
        DateTime now = DateTime.Now;
        System.IO.File.AppendAllText(debugPath, "(something is working)" + now.ToLongTimeString() + "\n");
    }
