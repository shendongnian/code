    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Security.Permissions;
    
    namespace filewatchtest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Run();
            }
    
            [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
            public static void Run()
            {
                string[] args = System.Environment.GetCommandLineArgs();
    
                // if directory not specified then end program
                if (args.Length != 2)
                {
                    Console.WriteLine("Usage: filewatchtest.exe directory");
                    return;
                }
    
                // create a new fileSystemWatcher and set its properties
                FileSystemWatcher watcher = new FileSystemWatcher();
                watcher.Path = args[1];
    
                // set the notify filters
                watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
    
                // set the file extension filter
                watcher.Filter = "*.docx";
    
                // add event handlers
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.Created += new FileSystemEventHandler(OnChanged);
                watcher.Deleted += new FileSystemEventHandler(OnChanged);
                watcher.Renamed += new RenamedEventHandler(OnRenamed);
    
                // bengin watching
                watcher.EnableRaisingEvents = true;
    
                // wait for the user to quit the program
                Console.WriteLine("Plress q to quit the program");
                while (Console.Read()!='q');
    
    
            }
    
            static void OnRenamed(object sender, RenamedEventArgs e)
            {
                Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            }
    
            static void OnChanged(object sender, FileSystemEventArgs e)
            {            
                Console.WriteLine("File:" + e.FullPath + " " + e.ChangeType);
            }
    
            
    
        }
    }
