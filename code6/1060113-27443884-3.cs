    public class ResourceItem : ConfigurationElement
    {
        [ConfigurationProperty("title", IsRequired = true)]
        public string Title
        {
            get { return (string)this["title"]; }
        }
        [ConfigurationProperty("details", IsRequired = true)]
        public string Details
        {
            get { return (string)this["details"]; }
        }
    }
