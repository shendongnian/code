    public string Name1
    {
        get
        {
            return ConfigurationManager.AppSettings["Name1"] ?? ThrowConfigException("Name1 does not exist in the config file");
        }
    }
