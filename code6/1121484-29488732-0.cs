    /// <summary>
    /// The <see cref="IsMuted" /> property's name.
    /// </summary>
    public const string IsMutedPropertyName = "IsMuted";
    
    private bool _isMuted = true;
    
    /// <summary>
    /// Sets and gets the IsMuted property.
    /// Changes to that property's value raise the PropertyChanged event. 
    /// </summary>
    public bool IsMuted
    {
        get
        {
            return _isMuted;
        }
    
        set
        {
            if (_isMuted == value)
            {
                return;
            }
           
            //IsMuted will always return true
            _isMuted = true;
            RaisePropertyChanged("IsMuted");
        }
    }
