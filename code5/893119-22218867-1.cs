    protected bool StopFiringPropertyChanged { get; set; }
    
    protected virtual void OnPropertyChanged(string propertyName)
    {
        if (StopFiringPropertyChanged) 
        {
            return;
        }
        
        // fire event
    }
