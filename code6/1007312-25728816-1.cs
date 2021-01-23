    public Visibility Auth
    {
        get
        {
            return auth.Auth;
        }
        set
        {
            auth.Auth = value;
            NotifyPropertyChanged("Auth");
        }
    }
