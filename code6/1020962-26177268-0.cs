    [XmlIgnore]
	[XmlElement("AttributeValue", IsNullable = true)]
    public string[] AttributeValue
    {
        get { return attributeValueField; }
        set { attributeValueField = value; }
    }
