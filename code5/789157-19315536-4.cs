    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ImageContainer> MyImageCollection { get; set; }
        public ViewModel()
        {
            MyImageCollection = new ObservableCollection<ImageContainer>();
            MyImageCollection.Add(new ImageContainer{Source = xxx});
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
    public class ImageContainer : INotifyPropertyChanged
    {
        private BitmapImage _source;
        public BitmapImage Source
        {
            [DebuggerStepThrough]
            get { return _source; }
            [DebuggerStepThrough]
            set
            {
                if (value != _source)
                {
                    _source = value;
                    OnPropertyChanged("Source");
                }
            }
        }
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = System.Threading.Interlocked.CompareExchange(ref PropertyChanged, null, null);
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
