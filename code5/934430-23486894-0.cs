    private bool _isPrintAllowed;
    
    public bool IsPrintAllowed{
    get{ return _isPrintAllowed;}
    set{_isPrintAllowed = value;
    RaisePropertyChanged(() => IsPrintAllowed)}
