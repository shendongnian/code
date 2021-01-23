    public class ViewModel : INotifyPropertyChanged, IObserver<string>
    {
        readonly ListCollectionView _listCollectionView;
        public ViewModel()
        {
            LogEntries = new ObservableCollection<string>();
            _listCollectionView = CollectionViewSource.GetDefaultView(LogEntries) as ListCollectionView;
            if (_listCollectionView != null)
            {
                MyWorker worker = new MyWorker();
                worker.Subscribe(this);
                worker.StartWork();
            }
        }
        public ObservableCollection<string> LogEntries { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public void OnNext(string logEntry)
        {
            _listCollectionView.Dispatcher.InvokeAsync(() => LogEntries.Add(logEntry));
        }
        public void OnCompleted()
        {
            // clean up goes here
        }
        public void OnError(Exception error)
        {
            // error handling goes here
        }
    }
