        private List<string> _myList;
        public List<string> MyList
        {
            get { return _myList; }
            set
            {
                if (Equals(value, _myList)) return;
                _myList = value;
                OnPropertyChanged();
            }
        }
