        private int _myList;
        public List<YourType> MyList
        {
            get { return _myList; }
            set
            {
                _myList = value;
                NotifyPropertyChanged("MyList");
            }
        }
        private int _myIndex;
        public int MyIndex 
        {
            get { return _myIndex; }
            set
            {
                _myIndex= value;
                NotifyPropertyChanged("MyIndex");
            }
        }
