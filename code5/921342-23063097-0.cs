    [Ignore]
    public string[] Attempts { get; set; }
    public string[] AttemptsMetadata
    {
        get{ return Attempts.Aggregate((ac, i) => ac + i + ";"); }
        set{ Attempts = value.Split(';'); }
    }
