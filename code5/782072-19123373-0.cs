     private string _myString;
        /// <summary>
        /// Sets and gets the myString property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string myString
        {
            get
            {
                return _myString;
            }
            set
            {
                if (_myString == value)
                {
                    return;
                }
                RaisePropertyChanging("myString");
                _myString = value;
                RaisePropertyChanged("myString");
            }
        }
