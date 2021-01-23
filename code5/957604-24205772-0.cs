     string _signalName, _signalValue;
        public string SignalName
        {
            get
            {
                return _signalName;
            }
            set
            {
                _signalName = value;
                OnPropertyChanged("SignalName");
            }
        }
        public string SignalValue
        {
            get
            {
                return _signalValue;
            }
            set
            {
                _signalValue = value;
                OnPropertyChanged(SignalValue);
            }
        }
