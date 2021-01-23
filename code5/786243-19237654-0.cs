    private string userName;
    public string UserName
    {
        get { return userName; }
        set
        {
            if (value != userName)
            {
                userName = value;
                RaisePropertyChanged("UserName");
            }
        }
    }
