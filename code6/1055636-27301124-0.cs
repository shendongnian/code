    private Timer timer;
    
    public bool Healing
    {
    get
    {
    return timer.Enabled;
    }
    set
    {
    timer.Enabled=value;
    }
    }
