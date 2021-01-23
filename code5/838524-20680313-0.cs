    [XmlIgnore]
    public DateTime ToDate { get; set; }
    [XmlAttribute("ToDate")]
    public string ToDateString 
    {
        get { return ToDate.ToString("MM/dd/yyyy"); }
        set { ToDate = DateTime.Parse(value); }
    }
