    private BehaviorSubject<bool> _isActive;
      
    public bool IsActive
    {
        get { return _isActive.Value; }
        set { _isActive.OnNext(value); }
    }
