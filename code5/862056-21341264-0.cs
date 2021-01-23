    [XmlArray]
    [XmlArrayItem("data", typeof(sessionData))]
    [XmlArrayItem("properties", typeof(sessionProperties))]
    public object[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
