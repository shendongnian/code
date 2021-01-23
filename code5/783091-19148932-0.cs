    private string _Terminal;
        public string Terminal
        {
            get
            {
                return _Terminal;
            }
            set
            {
                _Terminal = value;
                OnPropertyChanged("Terminal");
            }
        }
