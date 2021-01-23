    public class ViewModel : INotifyPropertyChanged
    {
        private readonly SynchronizationContext _synchronizationContext = SynchronizationContext.Current;
        public ViewModel()
        {
            DatabaseServer = "AnyServer";
            DatabaseName = "Any name";
            Model m = new Model();
            Task.Run(() => m.DoWork(this));
        }
        public string DatabaseServer { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUsername { get; set; }
        public string DatabasePassword { get; set; }
        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                if (value == _progress) return;
                _progress = value;
                OnPropertyChanged("Progress");
                Console.WriteLine(@"Progress.set() = " + _progress);
            }
        }
        // This is called by an external class
        public void OnProgressChanged(object sender, ProgressChangedEventArgs args)
        {
            _synchronizationContext.Send(delegate { Progress = args.ProgressPercentage; }, null);
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
