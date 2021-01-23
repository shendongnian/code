    private string _timespan;
    public string Timespan 
    {
        get { return _timespan; }
        set
        {
            _timespan = value;
            StartDate = DateTime.Parse(Timespan.Substring(0, 10));
            EndDate = DateTime.Parse(Timespan.Substring(12));
        }
    }
