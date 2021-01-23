    public class AkismetSettings : ConfigurationSection
    {
        private static AkismetSettings settings = ConfigurationManager.GetSection("akismet") as AkismetSettings;
    
        public static AkismetSettings Settings
        {
            get
            {
                return settings;
            }
        }
    
        [ConfigurationProperty("key", IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
            set { this["key"] = value; }
        }
    
    
        [ConfigurationProperty("registeredsite", IsRequired = true)]
        public string RegisteredSite
        {
            get { return (string)this["registeredsite"]; }
            set { this["registeredsite"] = value; }
        }
    }
