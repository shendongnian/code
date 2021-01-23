    using System;
    using System.IO;
    using System.Security.Permissions;
    using System.Threading.Tasks;
    
    public class Watcher
    {
    
        public static void Main()
        {
            Run();
    
        }
    
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Run()
        {
    
            // Create a new FileSystemWatcher and set its properties.
            RecurseDirectory();
    
            Console.ReadKey();
        }
    
        private static void RecurseDirectory(string path = @"T:\")
        {
            try
            {
                SetWatcher(path);
                Parallel.ForEach(Directory.GetDirectories(path), RecurseDirectory);
            }
            catch (Exception e)
            {
                //Ignore
            }
        }
    
    
        private static void SetWatcher(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = path;
            /* Watch for changes in LastAccess and LastWrite times, and
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            //watcher.Filter = "*.txt";
            // Add event handlers.        
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }
    
        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }
    
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
