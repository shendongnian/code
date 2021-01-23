    public static EmailConfigurationSection EmailConfiguration
    {
        get
        {
            return ConfigurationManager.GetSection("EmailConfigurationSection") as EmailConfigurationSection;
        }
    }
