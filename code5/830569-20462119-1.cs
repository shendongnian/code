    public string FirstName
    {
        get
        {
            return CurrentCustomer.FirstName;
        }
        set
        {
            CurrentCustomer.FirstName = value;
            OnPropertyChanged("FirstName");
        }
    }
