    public String SearchText
    {
        ...
        set
        {
           serachText = value;
           NotifyPropertyChanged();
           UpdateResults();
        }
    }
    
    public void UpdateResults()
    {
         ...
    }
