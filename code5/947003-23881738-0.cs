    using System;
    using System.Collections.Concurrent;
    using System.IO;
    using System.ServiceProcess;
    using System.Text;
    using System.Threading;
    using System.Timers;
    using TestWindowService;
    
    namespace TestCopy
    {
        public partial class Copy : ServiceBase
        {
            private FileSystemWatcher watcher;
            private System.Timers.Timer timer;
            private ConcurrentQueue<FileInfo> lastCreated;
    
            public Copy()
            {
                InitializeComponent();
    
                timer = new System.Timers.Timer();
                timer.Interval = 30000; //every 30 secs
                timer.Elapsed += (s, e) => CopyFiles();
    
                watcher = new FileSystemWatcher();
                watcher.Path = "C:\\INPUT\\";
                watcher.Filter = "*.*";
                //schedule the file for copying on the next tick
                watcher.Created += (s, e) => lastCreated.Enqueue(new FileInfo(e.FullPath));
            }
    
            protected override void OnStart(string[] args)
            {
                timer.Enabled = true;
                watcher.EnableRaisingEvents = true;
    
                Library.WriteErrorLog("Test window service started");
            }
    
            private void CopyFiles()
            {
                String output_dir = "D:\\OUTPUT\\";
                
                FileInfo fi;
                while (lastCreated.TryDequeue(out fi))
                    if (fi.Exists)
                        fi.CopyTo(Path.Combine(output_dir, fi.Name));
    
                Library.WriteErrorLog("File copy success");
            }
    
            protected override void OnStop()
            {
                watcher.EnableRaisingEvents = false;
                timer.Enabled = false;
    
                //empty the queue
                FileInfo fi;
                while (!lastCreated.IsEmpty)
                    lastCreated.TryDequeue(out fi);
    
                Library.WriteErrorLog("Test window service stopped");
            }
        }
    }
