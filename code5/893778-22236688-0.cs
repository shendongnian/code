        class SlowFileSystemWatcher : FileSystemWatcher
        {
            public delegate void SlowFileSystemWatcherEventHandler(object sender, FileSystemEventArgs args);
            public event SlowFileSystemWatcherEventHandler SlowChanged;
            public DateTime LastFired { get; private set; }
            public SlowFileSystemWatcher(string path)
                : base(path)
            {
                Changed += HandleChange;
                Created += HandleChange;
                Deleted += HandleChange;
                LastFired = DateTime.MinValue;
            }
            private void SlowGeneralChange(object sender, FileSystemEventArgs args)
            {
                if (LastFired.Add(TimeSpan.FromSeconds(5)) < DateTime.UtcNow)
                {
                    SlowChanged.Invoke(sender, args);
                    LastFired = DateTime.UtcNow;
                }
            }
            private void HandleChange(object sender, FileSystemEventArgs args)
            {
                SlowGeneralChange(sender, args);
            }
            protected override void Dispose(bool disposing)
            {
                SlowChanged = null;
                base.Dispose(disposing);
            }
        }
