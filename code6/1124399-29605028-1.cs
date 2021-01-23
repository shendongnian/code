        [XmlElement(Form = XmlSchemaForm.Unqualified, Order = 0)]
        public decimal weight { get; set; }
        [XmlIgnore]
        public bool weightSpecified { get; set; }
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool weightSpecified
    {
        get
        {
            return this.weightFieldSpecified;
        }
        set
        {
            this.weightFieldSpecified = value;
            this.RaisePropertyChanged("weightSpecified");
        }
    }
