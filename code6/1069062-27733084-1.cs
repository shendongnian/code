    // Do not map!
    public TimeFrame TimeFrame { get; set; }
    // Map!
    public int TimeFrameInt {
        get { return (int)TimeFrame; }
        set { TimeFrame = (TimeFrame)value; }
    }
