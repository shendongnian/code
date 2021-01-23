    [Serializable()]
    [System.Xml.Serialization.XmlRoot("packages")]
    public class PackageCollection
    {
        [System.Xml.Serialization.XmlElement("package", typeof(Package))]
        public Package[] Packages { get; set; }
    }
