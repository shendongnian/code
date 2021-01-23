    public class MyConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("MyProperty")]
        public string MyProperty
        {
            get { return (string)this["MyProperty"] }
            set { this["MyProperty"] = value;
        }
    }
