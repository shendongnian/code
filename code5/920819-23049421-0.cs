    class ProvinceViewModel : INotifyPropertyChanged
    {
        private Province _Province;
    
        public string Name
        {
            get { return _Province.Name; }
            set
            {
                if (_Name == value) return;
                _Province.Name = value;
                OnPropertyChanged("Name");
            }
        }
    
        public ProvinceViewModel(Province province)
        {
            _Province = province;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
