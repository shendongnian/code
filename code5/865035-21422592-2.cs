    private int ReadLinesCount = 0;
    public static void RunWatcher()
    {
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = "c:\folder";   
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;   
        watcher.Filter = "*.txt";    
        watcher.Changed += new FileSystemEventHandler(OnChanged);
        watcher.EnableRaisingEvents = true;
    
    }
   
    private static void OnChanged(object source, FileSystemEventArgs e)
    {
          int totalLines - File.ReadLines(path).Count();
          int newLinesCount = totalLines - ReadLinesCount;
          File.ReadLines(path).Skip(ReadLinesCount).Take(newLinesCount );
          ReadLinesCount = totalLines;
    }
