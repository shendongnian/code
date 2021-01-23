     protected override void OnStart(string[] args)
        {
            file = new StreamWriter("C:\\Public\\fswThread." + DateTime.Now.Millisecond.ToString() + ".txt");
            System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
            watcher.Path = @"C:\Windows";
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName   | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler( OnChanged );
            watcher.EnableRaisingEvents = true;
        }
        protected override void OnStop()
        {
            file.Close();
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            file.WriteLine( "C: " + e.FullPath );
            file.AutoFlush = true;
            if (file.BaseStream.Length > 100)
            {
                file.Flush();
                file.Close();
                file = new StreamWriter("C:\\Public\\fswThread." + DateTime.Now.Millisecond.ToString() + ".txt");
            }
        }
