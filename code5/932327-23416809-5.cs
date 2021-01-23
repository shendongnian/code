    public class Sep : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            [DebuggerStepThrough]
            get { return _title; }
            [DebuggerStepThrough]
            set
            {
                if (value != _title)
                {
                    _title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        private ImageSource _thumbnailImage;
        public ImageSource ThumbnailImage
        {
            [DebuggerStepThrough]
            get { return _thumbnailImage; }
            [DebuggerStepThrough]
            set
            {
                if (value != _thumbnailImage)
                {
                    _thumbnailImage = value;
                    OnPropertyChanged("ThumbnailImage");
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
