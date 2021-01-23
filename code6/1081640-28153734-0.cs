    CustomObject _customObject = ... // was created successfully
        public CustomObject customObject
        {
            get { return _customObject ; }
            set {
                _customObject  = value;
            
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("customObject"));
                }
        }
