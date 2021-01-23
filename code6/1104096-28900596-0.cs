    private string _AccountType;
        public string AccountType
        {
            get { return _AccountType; }
            set 
            { 
                _AccountType = value; 
                //OnPropertyChanged stuff here.
            }
        }
