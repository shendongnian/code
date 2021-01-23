    private DateTime _pe1;
    public string PassportEnd1
    {
        get { return _pe1.ToString("yyyymmdd"); }
        set { _pe1 = DateTime.ParseExact(value, "dd.mm.yyyy", CultureInfo.InvariantCulture); }
    }
