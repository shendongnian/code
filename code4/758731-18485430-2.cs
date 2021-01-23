        private string _name;
        public string Name
        {
            get { return _name.BarkYourName(); }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
