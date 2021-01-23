    using System;
    using System.IO;
    using NServiceBus;
    using NServiceBus.Satellites;
    public class FileSystem : ISatellite
    {
        private FileSystemWatcher _watcher;
        public bool Handle(TransportMessage message)
        {
            return true;
        }
        public void Start()
        {
            _watcher = new FileSystemWatcher
            {
                Path = @"c:\",
                NotifyFilter = NotifyFilters.LastAccess |    NotifyFilters.LastWrite
                               | NotifyFilters.FileName | NotifyFilters.DirectoryName,
                Filter = "*.txt"
            };
            _watcher.Changed += OnChanged;
            _watcher.Created += OnChanged;
            _watcher.Deleted += OnChanged;
            _watcher.EnableRaisingEvents = true;
        }
        public void Stop()
        {
            _watcher.Dispose();
        }
        public Address InputAddress
        {
            get { return Address.Parse("FileSystemSatellite"); }
        }
        public bool Disabled
        {
            get { return false; }
        }
        // Define the event handlers. 
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or    deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            // fire off an event here...
        }
    }
