    protected XmlSerializer ValueSerializer
    {
        get
        {
            if (valueSerializer == null)
            {
                valueSerializer = new XmlSerializer(typeof(TVal));
            }
            return valueSerializer;
        }
    }
