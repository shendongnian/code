    public bool CanLogin 
    { 
        get
        {
            return !string.IsNullOrEmpty(Ip) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Port); 
        }
    }
