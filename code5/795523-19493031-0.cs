    private recipientsGsm[] itemsField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("gsm", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
    public recipientsGsm[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
