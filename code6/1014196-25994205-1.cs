    private DateTime dateTimeField;
    
    ...
    
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public System.DateTime dateTime
        {
            get
            {
                return this.dateTimeField;
            }
            set
            {
                if ((dateTimeField.Equals(value) != true))
                {
                    this.dateTimeField = value;
                    this.OnPropertyChanged("dateTime");
                }
            }
        }
