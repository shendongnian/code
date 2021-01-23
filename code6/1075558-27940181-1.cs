    private bool _active;
    public bool Active
    {
        get { return _active; }
        set
        {
            _active = value;
            OnPropertyChanged();
        }
    }
