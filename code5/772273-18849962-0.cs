    public List<string> Schemes
    {
        get { return this.Values.Keys.ToList(); }
    }
    public Dictionary<string, Dictionary<string, double>> Values { get; internal set; }
