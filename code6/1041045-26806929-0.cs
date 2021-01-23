    public sealed class Container : INotifyPropertyChanged
    {
        public string location
        { 
            get { return _location; }
            set { _location = value; RaisePropertyChanged("location"); }
        }
        private string _location;
        ... 
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(new PropertyChangedEventArgs(this, propName));
        }
    }
