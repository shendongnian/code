    private string _user;
    public string User
    {
        get { return _user; }
        set
        { 
            if(!(value == ""))
                _user = value; 
        }
    }
