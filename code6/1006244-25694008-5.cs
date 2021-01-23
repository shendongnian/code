    public string File
    {
        get { return _file; }
        set
        {
            _file = value;
            RaisePropertyChanged();
            RaisePropertyChanged(() => CurrentState);
        }
    }
    private string _file;
    public string CurrentState
    {
        get { return (File == null ? "State1" : "State2"); }
    }
