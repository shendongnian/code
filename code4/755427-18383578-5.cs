    protected XmlSerializer ValueSerializer
    {
        get
        {
            if (valueSerializer == null)
            {
                valueSerializer = new XmlSerializer(typeof(TVal), 
                    new[]
                        {
                            typeof(List<string>), 
                            typeof(List<int>)
                        });
            }
            return valueSerializer;
        }
    }
