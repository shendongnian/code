    public string Email
    {
        //get
        set
        {
            this.email = value;
            this.OnPropertyChanged("CurrentUser");
        }
    }
