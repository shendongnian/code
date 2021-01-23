    public bool IsRunning
    {
        get { return isRunning; }
        set
        {
            isRunning = value;
            NotifyPropertyChanged("IsRunning");
            // Update your other properties here
        }
    }
