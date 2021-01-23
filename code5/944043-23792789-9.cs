        protected override void OnStart(string[] args)
        {
            _log.Debug("LoggingService starting.");
            
            _log.Debug("Initializing FileSystemWatcher .");
            _watcher = new FileSystemWatcher { Path = AppConfig.MonitorFolder, IncludeSubdirectories = true };
            _watcher.Created += File_OnChanged;      
            _watcher.EnableRaisingEvents = true; 
            _log.Debug("FileSystemWatcher has been started.");
            ThreadPool.QueueUserWorkItem(ProcessExistingFiles, AppConfig.MonitorFolder);
            _log.Debug("Processing of existing files has been queued.");
        }
        private void ProcessExistingFiles(object folderPathObj)
        {
             var folderPath = folderPathObj as string;
             if (folderPath  != null)
             {
             }
        }
