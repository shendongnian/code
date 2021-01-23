    private double _bpm;
    private double _bps;
    private double Bpm
    {
        get
        {
            return _bpm;
        }
        set
        {
            _bpm = value;
            _bps = value / 60;
        }
    }
    private double Bps
    {
        get
        {
            return _bps;
        }
        set
        {
            _bps = value;
            _bpm = value * 60;
        }
    }
