    public class ViewModel : INotifyPropertyChanged
    {
        private string _myProperty;
        public string MyProperty
        {
            [DebuggerStepThrough]
            get { return _myProperty; }
            [DebuggerStepThrough]
            set
            {
                if (value != _myProperty)
                {
                    _myProperty = value;
                    OnPropertyChanged("MyProperty");
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
