    private DateTime _displayTime;
    public DateTime DisplayTime
    {
        get { return _displayTime; }
        set { 
            _displayTime = value;
            TxtClock.Text = String.Format("{0:HH:mm:ss}", _displayTime);
        }
    }
