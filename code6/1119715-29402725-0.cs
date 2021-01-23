    // Each method returns the object so you can chain
    public class ConfigurationSettings
    {
        public ConfigurationSettings Initialize()
        {
            // Init code here
            return this;
        }
        public ConfigurationSettings WithConnectionString(string connectionString)
        {
            // Do stuff with connection string
            return this;
        }
        public ConfigurationSettings InSingleUserMode()
        {
            // Set single user mode etc...
            return this;
        }
    }
