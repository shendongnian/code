    public string DurationStr
    {
        get { return Duration.ToString(@"m\:ss"); }
    }
    public TimeSpan Duration
    {
        get { return _duration; }
        set
        {
            _duration = value;
            RaisePropertyChanged("Duration");
            RaisePropertyChanged("DurationStr");
        }
    }
    private TimeSpan _duration;
