    public string FirstName
    {
        get { return _firstName; }
        set
        {
            _firstName = value;
            RaisePropertyChanged(() => FirstName);
        }
    }
    private string _firstName;
