    [XmlAttribute("Name")]
    public string Name {get;set;}
    [XmlElement("Name")]
    public string NameAlt {
        get { return Name; }
        set { Name = value; }
    }
    // to prevent serialization (doesn't affect deserialization)
    public bool ShouldSerializeNameAlt() { return false; }
