    private static FileSystemWatcher _fileWatcher;
    private static FileSystemWatcher _dirWatcher;
    
    static void Main(string[] args)
    {
         _fileWatcher = new FileSystemWatcher(@"c:\users\axy\desktop");
         _fileWatcher.IncludeSubdirectories = true;
         _fileWatcher.NotifyFilter = NotifyFilters.FileName;
         _fileWatcher.EnableRaisingEvents = true;
         _fileWatcher.Deleted += OnDeleteEvent
    
        _dirWatcher = new FileSystemWatcher(Directory);
        _dirWatcher.IncludeSubdirectories = true;
        _dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
        _dirWatcher.EnableRaisingEvents = true;
        _dirWatcher.Deleted += OnDeleteEvent
    }
    
    static void OnDeleteEvent(object sender, FileSystemEventArgs e)
    {
        if(sender == _dirWatcher)
        {
            Console.WriteLine("Directory:{0}",e.FullPath);
        }
        else
        {
            Console.WriteLine("File:{0}",e.FullPath);
        }
    }
