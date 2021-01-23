    private bool _isEnabled;
    public bool IsEnabled
    {
        get { return true; }
        set { _isEnabled = value
             SetPropertyChanged("IsEnabled");  
         };
    }
