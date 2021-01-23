    public CustomContext()
                    : base(CloudConfigurationManager.GetSetting("dbActivity"))
    {
        // stuff here
    }
