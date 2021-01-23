    private string _user;
    public string User
    {
        get { return _user; }
        set
        {
            _user = value;
            this.RaisePropertyChanged(x => x.User);
        }
    }
