    public class MyCollection<T> : ObservableCollection<T>, INotifyPropertyChanged
    {
        // implementation goes here...
        //
        private int _myCount;
        public int MyCount
        {
            [DebuggerStepThrough]
            get { return _myCount; }
            [DebuggerStepThrough]
            set
            {
                if (value != _myCount)
                {
                    _myCount = value;
                    OnPropertyChanged("MyCount");
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
