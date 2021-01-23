    public class MyCustomConfigurationSection
    {
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
