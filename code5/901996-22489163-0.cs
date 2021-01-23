    public class ViewModel : IDisposable
    {
        // Constructor.
        public ViewModel()
        {
            // capture dispatcher for current thread (model should be created on UI thread)
            _dispatcher = Dispatcher.CurrentDispatcher;
            // start watching file system
            _watcher = new FileSystemWatcher("C:\\Documents");
            _watcher.Created += Watcher_Created;
            _watcher.Deleted += Watcher_Deleted;
            _watcher.Renamed += Watcher_Renamed;
            _watcher.EnableRaisingEvents = true;
            // initialize combo data
            _comboData = new ObservableCollection<string>(Directory.GetFiles(_watcher.Path));
            ComboData = new ReadOnlyObservableCollection<string>(_comboData);
        }
        // Disposal
        public void Dispose()
        {
            // dispose of the watcher
            _watcher.Dispose();
        }
        // the dispatcher is used to marshal events to the UI thread
        private readonly Dispatcher _dispatcher;
        // the watcher is used to track file system changes
        private readonly FileSystemWatcher _watcher;
        // the ComboData property should be bound to the UI
        public ReadOnlyObservableCollection<string> ComboData { get; private set; }
        // the backing field for the ComboData property
        private readonly ObservableCollection<string> _comboData;
        // called on a background thread when a file/directory is created
        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            _dispatcher.BeginInvoke(new Action(() => _comboData.Add(e.FullPath)));
        }
        // called on a background thread when a file/directory is deleted
        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            _dispatcher.BeginInvoke(new Action(() => _comboData.Remove(e.FullPath)));
        }
        // called on a background thread when a file/directory is renamed
        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            _dispatcher.BeginInvoke(new Action(() =>
                {
                    _comboData.Remove(e.OldFullPath);
                    _comboData.Add(e.FullPath);
                }));
        }
    }
