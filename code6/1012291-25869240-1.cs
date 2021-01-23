    private string _name1;
    public string Name1
    {
        get
        {
            return _name 1 ?? (_name1 = ConfigurationManager.AppSettings["Name1"]) ?? ThrowConfigException("Name1 does not exist in the config file");
        }
    }
