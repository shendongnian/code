    private string _status;
    Public Event OnStatusChanged;
    public string Status
    {
        get
        {
            return _status;
        }
        set
        {
            _status = value;
            RaiseEvent OnStatusChanged;
        }
    }
