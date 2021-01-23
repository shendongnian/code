    [Column]
    public int StartTime
    {
        get
        {
            return this.StartTimeTS.TotalSeconds;
        }
        set
        {
            this.StartTimeTS = new TimeSpan(0, 0, value);
        }
    }
    
    private TimeSpan _startTime;
    public TimeSpan StartTimeTS
    {
        get { return _startTime; }
        set
        {
            if (_startTime != value)
            {
                NotifyPropertyChanging("StartTime");
                _startTime = value;
                NotifyPropertyChanged("StartTime");
            }
        }
    }
