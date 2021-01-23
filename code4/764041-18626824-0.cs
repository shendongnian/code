    [XmlIgnore]
    public float? RelativeX
    {
        get { return this.RelativeX; }
        set { this.RelativeX = value; }
    }
    
    [XmlAttribute("RelativeX")]
    public float RelativeXValue
    {
        get { return this.RelativeX.Value; }
        set { this.RelativeX = value; }
    }
    
    [XmlIgnore]
    public bool RelativeXValueSpecified
    {
        get { return this.RelativeX.HasValue; }
    }
