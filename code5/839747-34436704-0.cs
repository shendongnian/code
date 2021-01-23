    public ICollection<string> List { get; set; }
    public string ListString
    {
        get { return string.Join(",", List); }
        set { List = value.Split(',').ToList(); }
    }
