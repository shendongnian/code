    public class DirectoryEnumerator
    {
        public class FileEventArgs : EventArgs
        {
            public FileInfo FileInfo { get; }
            public FileEventArgs(FileInfo fileInfo)
            {
                FileInfo = fileInfo;
            }
        }
        public class DirectoryEventArgs : EventArgs
        {
            public DirectoryInfo DirectoryInfo { get; }
            public DirectoryEventArgs(DirectoryInfo directoryInfo)
            {
                DirectoryInfo = directoryInfo;
            }
        }
        public class EventEnumerator<T> : IEnumerable<T>, IEnumerator<T>
        {
            private readonly Queue<T> _queue = new Queue<T>();
            private readonly ManualResetEvent _event;
            public bool Started { get; set; }
            
            public EventEnumerator()
            {
                _event = new ManualResetEvent(false);
            }
            public void Action(Action action)
            {
                Task.Run(() => action.Invoke()).ContinueWith(task => { MarkComplete(); });
            }
            public void Callback(T value)
            {
                Started = true;
                lock (_queue)
                {
                    _queue.Enqueue(value);
                    _event.Set();
                }
            }
            public void MarkComplete()
            {
                Started = false;
                _event.Set();
            }
            public void Dispose()
            {
            }
            public bool MoveNext()
            {
                _event.WaitOne();
                var notComplete = IsNotComplete();
                if (notComplete)
                {
                    lock (_queue)
                    {
                        Current = _queue.Dequeue();
                        if (_queue.Count == 0)
                            _event.Reset();
                    }
                }
                return IsNotComplete();
            }
            private bool IsNotComplete()
            {
                return _queue.Count > 0 || Started;
            }
            public void Reset()
            {
                lock (_queue)
                {
                    _queue.Clear();
                }
            }
            public T Current { get; private set; }
            object IEnumerator.Current
            {
                get { return Current; }
            }
            public IEnumerator<T> GetEnumerator()
            {
                while (this.MoveNext())
                {
                    if (Current != null)
                    {
                        yield return this.Current;
                    }
                }
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        public DirectoryEnumerator()
        {
        }
        public event EventHandler OnNewFile;
        private void ProcessFile(FileInfo path)
        {
            OnNewFile?.Invoke(this, new FileEventArgs(path));
        }
        public event EventHandler OnNewDirectory;
        private void ProcessDirectory(DirectoryInfo path)
        {
            OnNewDirectory?.Invoke(this, new DirectoryEventArgs(path));
        }
        public static IEnumerable<FileInfo> GetFiles(DirectoryInfo directoryInfo, bool recurse = true)
        {
            var directoryEnumerator = new DirectoryEnumerator();
            var eventEnumeratingEnumerable = new EventEnumerator<FileInfo>();
            eventEnumeratingEnumerable.Action(() => { directoryEnumerator.Enumerate(directoryInfo, recurse); });
            directoryEnumerator.OnNewFile +=
                (sender, eventHandler) =>
                {
                    eventEnumeratingEnumerable.Callback(((FileEventArgs)eventHandler).FileInfo);
                };
            return eventEnumeratingEnumerable;
        }
        public static IEnumerable<DirectoryInfo> GetDirectories(DirectoryInfo directoryInfo, bool recurse = true)
        {
            var directoryEnumerator = new DirectoryEnumerator();
            var eventEnumeratingEnumerable = new EventEnumerator<DirectoryInfo>();
            eventEnumeratingEnumerable.Action(() => { directoryEnumerator.Enumerate(directoryInfo, recurse); });
            directoryEnumerator.OnNewDirectory +=
                (sender, eventHandler) =>
                {
                    eventEnumeratingEnumerable.Callback(((DirectoryEventArgs) eventHandler).DirectoryInfo);
                };
            return eventEnumeratingEnumerable;
        }
        
        public void Enumerate(DirectoryInfo directoryInfo, bool recurse = true)
        {
            Enumerate(directoryInfo, recurse, ProcessFile, ProcessDirectory);
        }
        
        private void Enumerate(DirectoryInfo directoryInfo, bool recurse, Action<FileInfo> fileAction, Action<DirectoryInfo> directoryAction)
        {
            TryEnumerateFiles(directoryInfo, fileAction);
            TryEnumerateDirectories(directoryInfo, recurse, fileAction, directoryAction);
        }
        private void TryEnumerateDirectories(DirectoryInfo directoryInfo, bool recurse, Action<FileInfo> fileAction, Action<DirectoryInfo> directoryAction)
        {
            try
            {
                foreach (var subDir in directoryInfo.GetDirectories("*.*", SearchOption.TopDirectoryOnly))
                {
                    if (directoryAction != null)
                    {
                        directoryAction(subDir);
                    }
                    if (recurse)
                    {
                        Enumerate(subDir, true, fileAction, directoryAction);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Debug($"Failed to enumerate subdirectories within directory {directoryInfo.FullName}", ex);
            }
        }
        private void TryEnumerateFiles(DirectoryInfo directoryInfo, Action<FileInfo> fileAction)
        {
            try
            {
                foreach (var file in directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly))
                {
                    if (fileAction != null)
                    {
                        fileAction(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Debug($"Failed to enumerate files within directory {directoryInfo.FullName}", ex);
            }
        }
        private static void Examples()
        {
            // Recursive file enumeration
            var files1 = DirectoryEnumerator.GetFiles(new DirectoryInfo("C:\\")).ToList();
            // File enumeration
            var files2 = DirectoryEnumerator.GetFiles(new DirectoryInfo("C:\\"), false).ToList();
            // Recursive directory enumeration
            var directory1 = DirectoryEnumerator.GetDirectories(new DirectoryInfo("C:\\")).ToList();
            // Directory enumeration
            var directory2 = DirectoryEnumerator.GetDirectories(new DirectoryInfo("C:\\"), false).ToList();
            
            
            // Event enumeration
            var directoryEnumerator = new DirectoryEnumerator();
            directoryEnumerator.OnNewFile += (sender, file) => {
                // dosomething 
            };
            
            directoryEnumerator.OnNewDirectory += (sender, file) => {
                // dosomething 
            };
            directoryEnumerator.Enumerate(new DirectoryInfo("C:\\"), false);
        }
        
    }
