    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("deceasedBoolean", typeof(boolean))]
    [System.Xml.Serialization.XmlElementAttribute("deceasedDateTime", typeof(dateTime))]
    public Element Item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
