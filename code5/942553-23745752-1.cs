    private Status _status
    public enum Status
    {
        AuthRequired, AuthAttempted, AuthReceived, AuthError, AuthSuccessful
    }
    
    public Status Status
    {
        get { return _status; }
        set
        {
            _status = value;
            RaisePropertyChanged("Status");
        }
    }
