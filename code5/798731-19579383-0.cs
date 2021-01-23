    [System.Xml.Serialization.XmlElementAttribute("Start", typeof(System.DateTime), DataType="date", Order=2)]
    [System.Xml.Serialization.XmlElementAttribute("Stop", typeof(System.DateTime), DataType="date", Order=2)]
    [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
    public System.DateTime[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
