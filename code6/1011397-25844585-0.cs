        public List<YourType> MyList {get; set; }
        public int _myIndex;
        public int MyIndex 
        {
            get { return _myIndex; }
            set
            {
                _myIndex= value;
                NotifyPropertyChanged("MyIndex");
            }
        }
