    public int Number
    { 
        get { return number; }
        set 
        {
            if (value > 0) 
            {
                number = value;
                NotifyPropertyChanged("Number"); 
            }
        }
    }
