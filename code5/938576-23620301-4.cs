    class Joint : INotifyPropertyChanged
    {
        public decimal first 
        { 
            get { return _first; }
            set { _first = value; OnPropertyChanged(); }
        }
        private decimal _first;
        // and so forth with the other properties ...
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
        }
    }
