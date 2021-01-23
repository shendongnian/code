        public const string MyListPropertyName = "MyList";
        private List<string> _myList;
        /// <summary>
        /// Sets and gets the MyList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<string> MyList
        {
            get
            {
                return _myList;
            }
            set
            {
                if (_myList == value)
                {
                    return;
                }
                RaisePropertyChanging(MyListPropertyName);
                _myList = value;
                RaisePropertyChanged(MyListPropertyName);
            }
        }
