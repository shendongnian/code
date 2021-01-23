    public string UserName
    {
        get
        {
            return _userName;
        }
        set
        {
            _userName = value;
            WriteToDB(value);
        }
    }
    // etc
    private void WriteToDB(object value, [CallerMemberName] string propertyName = "")
    {
        // propertyName will be "UserName" when called above
    }
    // use like
    myUser.UserName = "Tommy";
