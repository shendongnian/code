    class Data : INotifyPropertyChanged
    {
        private string _displayUnits;
        public string DisplayUnits
        {
            get { return _displayUnits; }
            set
            {
                _displayUnits = value;
                OnPropertyChanged("DisplayUnits");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
