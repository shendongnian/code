    private string _name1;
    public string Name1
    {
        get
        {
            return 
                _name1 ?? 
                (_name1 = ConfigurationManager.AppSettings["Name1"]) ?? 
                throw new System.Configuration.ConfigurationErrorsException(nameof(Name1) + " does not exist in the config file");
        }
    }
