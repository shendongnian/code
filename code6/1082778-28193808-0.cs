    public String Town
        {
            get { return town; }
            set 
            {
                town = value;
                OnPropertyChanged("Town");
            }
        }
