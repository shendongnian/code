    private static readonly EmailConfigurationSection settings = ConfigurationManager.GetSection("EmailConfigurationSection") as EmailConfigurationSection;
    public static EmailConfigurationSection EmailConfiguration
    {
        get
        {
            return settings;
        }
    }
