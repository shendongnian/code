    [XmlIgnore]
    public List<MyObject> Objects{ get; set; }
    [XmlArray(ElementName = "OBJECT")]
    [XmlArrayItem(Type = typeof(int), ElementName = "PROPA")]
    [XmlArrayItem(Type = typeof(string), ElementName = "PROPB")]
    public List<object> XmlObjects
    {
        get
        {
            var xmlObjects = new List<object>();
            if (Objects != null)
            {
                xmlObjects.AddRange(Objects.SelectMany(x => new List<object>
                {
                    x.PropA,
                    x.PropB
                }));
            }
            return xmlObjects;
        }
        set { }
    }
