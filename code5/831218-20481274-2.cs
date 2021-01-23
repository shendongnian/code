    private string _firstName;
    public string FirstName 
    { 
        get{return _firstName;}
        set
        {
            if (_firstName == value) return;
            _firstName = value;
            OnPropertyChanged("FirstName");
        }
    }
