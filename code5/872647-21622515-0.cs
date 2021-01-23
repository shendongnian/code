    [Serializable]
    [XmlRoot("Scene")]
    [XmlType]
    public class Scene
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("IsActive")]
        public string Active { get; set; }
    }
