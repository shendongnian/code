    private _status _Status
    public enum _status
    {
        AuthRequired, AuthAttempted, AuthReceived, AuthError, AuthSuccessful
    }
    
    public _status Status
    {
        get { return _Status; }
        set
        {
            _Status = value;
            RaisePropertyChanged("Status");
        }
    }
