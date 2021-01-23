    public class ViewModel : INotifyPropertyChanged
    {
        private bool _isDoStuffButtonEnabled;
        public bool IsDoStuffButtonEnabled
        {
            get
            {
                return _isDoStuffButtonEnabled;
            }
            set
            {
                if (_isDoStuffButtonEnabled == value) return;
                _isDoStuffButtonEnabled = value;
                RaisePropertyChanged("IsDoStuffButtonEnabled");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
