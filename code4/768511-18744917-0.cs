    public string Name
    {
        get { return _user.Name; }
        set
        {
            if (value == _user.Name)
                return;
            _user.Name = value;
            NotifyPropertyChanged("UserName");
        }
    }
