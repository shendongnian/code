    public List<string> Categories { get; set; }
    public string Category
    {
        get
        {
            return String.Join(",", Categories);
        }
    }
