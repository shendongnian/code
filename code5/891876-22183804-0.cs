    private FileSystemWatcher watcher;
    
    public Service1()
    {
        InitializeComponent();
    }
    
    protected override void OnStart(string[] args)
    {
        watcher = new FileSystemWatcher();
        watcher.Path = @"c:\temp\service";
        watcher.Created += watcher_Created;
        watcher.EnableRaisingEvents = true;
    
    }
    
    protected override void OnStop()
    {
    }
    
    private void watcher_Created(object sender, FileSystemEventArgs e)
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(pathToExe, e.Name);
            EventLog.WriteEntry(e.Name);
    
            Process process = Process.Start(startInfo);
            process.EnableRaisingEvents = true;
        }
        catch (Exception ex)
        {
            EventLog.WriteEntry(ex.ToString());
        }
    }
