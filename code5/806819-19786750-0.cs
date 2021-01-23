     public class FileWatch
     {
        public FileWatch()
        {
           var watcher = new FileSystemWatcher {Path = @"C:\", EnableRaisingEvents = true};
           watcher.Created += (o, args) => watcher_change(o, args);              
        }
        public string[] watcher_change(object sender, FileSystemEventArgs e)
        {
           string[] filePaths = Directory.GetFiles(@"C:\", "*.dll");
           return filePaths;
        }
        public event EventHandler<object,FileSystemEventArgs>  YourEvent
        {
            add
            {
                watcher.Created += value;
            }
            remove
            {
                watcher.Created -= value;
            }
        } 
    }
