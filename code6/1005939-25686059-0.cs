    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ConfigMappings {
        [System.Xml.Serialization.XmlElementAttribute("Host")]
        public ConfigMappingsHost[] Host { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigMappingsHost {
        [System.Xml.Serialization.XmlElementAttribute("Component")]
        public ConfigMappingsHostComponent[] Component { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigMappingsHostComponent {
        [System.Xml.Serialization.XmlElementAttribute("Config")]
        public ConfigMappingsHostComponentConfig[] Config { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Enabled { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ConfigMappingsHostComponentConfig {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SubFolder { get; set; }
    }
