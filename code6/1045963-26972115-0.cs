    [XmlIgnore]
    public List<XmlPropertyValue> Values { get; set; }
    [XmlElement("value")]
    public List<XmlPropertyValue> ValuesForSerialization
    {
        get
        {
            var bla = Values.Where(o => o.ShouldSerializeValue()).ToList();
            return bla;
        }
        set { Values = value; }
    }
