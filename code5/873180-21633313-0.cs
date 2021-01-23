    public static void Main(string[] args)
    {
        Directory.CreateDirectory("dir1");
        Directory.CreateDirectory("dir2");
        Directory.CreateDirectory("dir3");
    
        Console.WriteLine("Main Thread Id: {0}", 
            Thread.CurrentThread.ManagedThreadId);
    
        const int watcherCount = 3;
        string[] dirs = new string[] { "dir1", "dir2", "dir3" };
    
        for (int i = 0; i < watcherCount; i++)
        {
            var watcher = new FileSystemWatcher();
            watcher.Path = dirs[i];
            watcher.Changed += (sender, e) =>
            {
                Console.WriteLine("File: {0} | Thread: {1}", e.Name,
                    Thread.CurrentThread.ManagedThreadId);
    
                Thread.Sleep(2000); // Simulate long operation
            };
            watcher.EnableRaisingEvents = true;
        }
    
        File.WriteAllText(@"dir1\test1", "hello");
        File.WriteAllText(@"dir2\test2", "hello");
        File.WriteAllText(@"dir3\test3", "hello");
    
        Thread.Sleep(10000);
    }
