    private static CustomConfigurationSection _current;
    private static readonly object _lock = new object();
    public static CustomConfigurationSection Current
    {
        get
        {
            lock(_lock) {
                return _current
                    ?? (_current = ConfigurationManager.GetSection(CustomSectionName) as CustomConfigurationSection);
            }
        }
    }
