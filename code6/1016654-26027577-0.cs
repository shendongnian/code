    internal class ServiceDomainProxy : MarshalByRefObject
    {
        private ServiceController controller;
        private List<FileSystemWatcher> watchers;
    
        public ServiceDomainProxy(ServiceController controller)
        {
            this.controller = controller;
        }
    
        public void CreateMonitor(Uri fileUri)
        {
            if(watchers == null)
                watchers = new List<FileSystemWatcher>();
    
            // Setup a FileWatcher on type, notify controller whenever it reloads
            FileInfo file = new FileInfo(fileUri.LocalPath);
            FileSystemWatcher watcher = new FileSystemWatcher
            {
                Path = file.DirectoryName,
                Filter = file.Name
            };
    
            watcher.Changed += fileChanged;
            watcher.EnableRaisingEvents = true;
            watchers.Add(watcher);
        }
    
        void fileChanged(object sender, FileSystemEventArgs e)
        {
            Controller.Log.Info("Reloading Service Assembly: {0}", e.Name);
            // TODO: Call the Reload method on controller
        }
    }
