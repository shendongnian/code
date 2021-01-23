        string _tText;
        public string Text
        {
            get { return _tText; }
            set
            {
                _tText = value;
                OnPropertyChanged("Text");
            }
        }
