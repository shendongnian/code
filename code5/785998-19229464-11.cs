    public bool IsEnabled
    {    
        set { 
            _isEnabled = value
            SetPropertyChanged<ViewModel>(x => x.IsEnabled);  
        }
    }
