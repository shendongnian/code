    public bool Enabled
    {
        get {
            return enabled;
        }
        set {
            if (value != enabled)
            {
                //Do Something if it changes
            }
            enabled = value;
        }
    }
    private bool enabled;
