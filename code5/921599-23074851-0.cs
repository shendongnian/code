    public event EventHandler<Mode> ModeChanged;
    public Mode NavigatorMode
    {
        get { return _navigatorMode; }
        set 
        {
            _navigatorMode = value;
            if(ModeChanged != null)
                ModeChanged(this, _navigatorMode);
        }
    }
