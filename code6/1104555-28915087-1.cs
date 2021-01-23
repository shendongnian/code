    public double BeatsPerSecond { get; set; }
    public double BeatsPerMinute
    {
        get { return BeatsPerSecond * 60; }
        set { BeatsPerSecond = value / 60; }
    }
