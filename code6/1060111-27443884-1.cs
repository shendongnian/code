    public class ResourceGroup : ConfigurationSection
    {
        [ConfigurationProperty("items", IsRequired=true)]
        public ResourceItemCollection Items
        {
            get { return (ResourceItemCollection)this["items"]; }
        }
    }
