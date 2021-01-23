    public static FactoryBO Create(string BusinessObjectName)
    {
        if (string.IsNullOrEmpty(BusinessObjectName))
        {
            return null;
        }
        FactoryBO valueObj = null;
        switch (BusinessObjectName.ToLower())
        {
            case "temporary registration": 
               valueObj = new TemporaryDriverRegistrationBO(); 
               break;
            case "driver registration": 
               valueObj = new DriverRegistrationBO(); 
               break;
        }
        return valueObj;
    }
