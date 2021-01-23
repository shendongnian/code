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
          NewLinesCount = totalLines - ReadLinesCount;
          File.ReadLines(path).Skip(ReadLinesCount).Take(NewLinesCount);
          ReadLinesCount = totalLines;
    }
