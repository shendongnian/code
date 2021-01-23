    [XmlIgnore]
    public List<DateTime> DoNotSerialize { get; set; }
    [XmlElement("time")]        
    public List<string> time
    {
        get { return DoNotSerialize.Select(item => item.ToString("yyyy-MM-dd")).ToList(); }
        set { DoNotSerialize = value.Select(item => DateTime.Parse(item)).ToList(); }
    }
