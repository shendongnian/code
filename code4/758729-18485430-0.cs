       private string _Name;
        public string Name
        {
            get { 
                return _Name.BarkYourName(); 
            }
            set { 
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
