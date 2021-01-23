    public bool IsEnabled
    {
        get { return isEnabled; }
        set { 
                 isEnabled = value;
                 PropertyChagned("IsEnabled");
            }
    }
