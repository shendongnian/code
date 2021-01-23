    public DateTime StartDate
    {
        get { return DateTime.Parse(Timespan.Substring(0, 10)); }
    }
    public DateTime EndDate
    {
        get { return DateTime.Parse(Timespan.Substring(12)); }
    }
