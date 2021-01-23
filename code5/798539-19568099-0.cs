            private static string[] filters = new string[] { ".txt", ".doc", ".docx" };
            static void Main(string[] args)
            {
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = @"C:\...\...\...";//your directory here
                /* Watch for changes in LastAccess and LastWrite times, and
                   the renaming of files or directories. */
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                   | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    
                //dont set this
                //watcher.Filter = "*.txt";
                
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
    
                watcher.EnableRaisingEvents = true;
                Console.ReadKey();
            }
    
            private static void OnChanged(object source, FileSystemEventArgs e)
            {
                
                if(filters.Contains(Path.GetExtension(e.FullPath)))
                Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            }
    
            private static void OnRenamed(object source, RenamedEventArgs e)
            {
                if (filters.Contains(Path.GetExtension(e.FullPath)))
                Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            }
