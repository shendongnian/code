    public class Data : INotifyPropertyChanged
    {
        private string _textFirst;
        public string TextFirst
        {
            [DebuggerStepThrough]
            get { return _textFirst; }
            [DebuggerStepThrough]
            set
            {
                if (value != _textFirst)
                {
                    _textFirst = value;
                    OnPropertyChanged("TextFirst");
                }
            }
        }
        private string _textSecond;
        public string TextSecond
        {
            [DebuggerStepThrough]
            get { return _textSecond; }
            [DebuggerStepThrough]
            set
            {
                if (value != _textSecond)
                {
                    _textSecond = value;
                    OnPropertyChanged("TextSecond");
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
