        public string SignalName
        {
            get
            {
                return _signalName;
            }
            set
            {
                _signalName = value;
                OnPropertyChanged("SignalName"); //Added
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
                OnPropertyChanged("SignalValue"); //NOTE: quotation marks added
            }
        }
