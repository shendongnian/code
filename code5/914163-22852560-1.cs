    public string Username    
    {         
        get { return _Username;}  
    
        set {
            _Username = value;
    
            NotifyOfPropertyChange(() => Username);
            NotifyOfPropertyChange(() => Can());
        }
    }
    public bool Can
    {
        get { return CanLogOn(Username); }
    }
    public bool CanLogOn(object parameter)
    {
        return !string.IsNullOrEmpty(Username); 
    }
