    private string _firstName;
    public string FirstName 
    { 
        get{return _firstName;}
        set
        {
            if (_firstName == value) return; //notice that "Value" is a confusing name for a property :)
            _firstName = value;
            OnPropertyChanged("FirstName");
        }
    }
