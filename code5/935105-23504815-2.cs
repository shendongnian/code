    public bool cb1Enabled
    {
        get { return bool _cb1Enabled; }
        set
        {
            _cb1Enabled = value;
            if (!_cb1Enabled)
                cb2Enabled = false;
            RaisePropertyChanged();
        }
    }
    private bool _cb1Enabled;
