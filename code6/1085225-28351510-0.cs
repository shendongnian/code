    [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, 
     DataType = "string", ElementName = "I_TIMETO")]
    public string I_TIMETO_STR
    {
        get
        {
            return this.i_TIMETOField.ToString("HH:mm:ss");
        }
        set
        {
            this.i_TIMETOField = DateTime.ParseExact(value, "HH:mm:ss", CultureInfo.InvariantCulture);
        }
    }
