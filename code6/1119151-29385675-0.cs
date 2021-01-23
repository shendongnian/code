    using System.Configuration;
    
    namespace ConditionalConfig
    {
        public class ConditionalConfigurationSection : ConfigurationSection
        {
            [ConfigurationProperty("selector", IsRequired = true, IsDefaultCollection = true)]
            public string Selector
            {
                get { return (string) base["selector"]; }
                set { base["selector"] = value; }
            }
    
            public new string this[string key]
            {
                get
                {
                    var result = Shared[key] ?? ((KeyValueConfigurationCollection) base[Selector])[key];
                    return result != null ? result.Value : null;
                }
            }
    
            [ConfigurationProperty("", IsRequired = true, IsDefaultCollection = true)]
            public KeyValueConfigurationCollection Shared
            {
                get { return (KeyValueConfigurationCollection) base[""]; }
            }
    
            [ConfigurationProperty("opt1", IsRequired = true)]
            public KeyValueConfigurationCollection Opt1
            {
                get { return (KeyValueConfigurationCollection) base["opt1"]; }
            }
    
            [ConfigurationProperty("opt2", IsRequired = true)]
            public KeyValueConfigurationCollection Opt2
            {
                get { return (KeyValueConfigurationCollection) base["opt2"]; }
            }
        }
    }
