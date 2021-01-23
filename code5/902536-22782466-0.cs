    sealed class LogEventSource : EventSource
    {
        public static LogEventSource Log = new LogEventSource();
        [Event(1, Level = EventLevel.LogAlways)]
        public void Debug(string message)
        {
            this.WriteEvent(1, message);
        }
    }
    /// <summary> 
    /// Storage event listner to do thread safe logging to a file.
    /// </summary> 
    sealed class StorageFileEventListener : EventListener
    {
        private object syncObj = new object();
        private List<string> logLines;
        private StorageFile logFile;
        private ThreadPoolTimer periodicTimer;
        public StorageFileEventListener()
        {
            Debug.WriteLine("StorageFileEventListener for {0}", GetHashCode());
            logLines = new List<string>();
        }
        // Should be called right after the constructor (since constructors can't have async calls)
        public async Task InitializeAsync()
        {
            logFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("logs.txt", CreationCollisionOption.OpenIfExists);
            // We don't want to write to disk every single time a log event occurs, so let's schedule a
            // thread pool task
            periodicTimer = ThreadPoolTimer.CreatePeriodicTimer((source) =>
            {
                // We have to lock when writing to disk as well, otherwise the in memory cache could change
                // or we might try to write lines to disk more than once
                lock (syncObj)
                {
                    if (logLines.Count > 0)
                    {
                        // Write synchronously here. We'll never be called on a UI thread and you
                        // cannot make an async call within a lock statement
                        FileIO.AppendLinesAsync(logFile, logLines).AsTask().Wait();
                        logLines = new List<string>();
                    }
                }
                CheckLogFile();
                
            }, TimeSpan.FromSeconds(5));
        }
        private async void CheckLogFile()
        {
            
            BasicProperties p = await logFile.GetBasicPropertiesAsync();
            if(p.Size > (1024 * 1024))
            {
                // TODO: Create new log file and compress old.
            }
        }
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            // This could be called from any thread, and we want our logs in order, so lock here
            lock (syncObj)
            {
                logLines.Add((string)eventData.Payload[0]);
            }
        }
    }
