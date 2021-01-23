    private string currentMouseTime = String.Empty;
    public string CurrentMouseTime
    {
        get { return value; }
        set 
        {
            if (currentMouseTime == value)
                return;
            currentMouseTime = value;
            OnPropertyChanged("CurrentMouseTime");
        }
    }
    
