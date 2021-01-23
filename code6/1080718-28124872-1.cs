        public class MyCustomConfigurationSection
        {
    private const string XmlNamespaceConfigurationPropertyName = "xmlns";
        [ConfigurationProperty(XmlNamespaceConfigurationPropertyName, IsRequired = false)]
                public string XmlNamespace
                {
                    get
                    {
                        return (string)this[XmlNamespaceConfigurationPropertyName];
                    }
                    set
                    {
                        this[XmlNamespaceConfigurationPropertyName] = value;
                    }
                }
        }
