    public bool IsEnabled
    {    
        set { 
            _isEnabled = value
            SetPropertyChanged(x => x.IsEnabled);  
        }
    }
