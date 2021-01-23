    private uint idField;
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public uint ID
    {
        get
        {               
            return this.idField;
        }
        set
        {
            int SOME_BOUND = 10000;
            if (value > SOME_BOUND)
            {
                throw new ApplicationException();
            }
            this.idField = value;
        }
    }
