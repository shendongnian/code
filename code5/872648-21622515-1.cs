    [Serializable]
    [XmlRoot("Scene")]
    [XmlType]
    public class Scene
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Type")]
        public string Type{ get; set; }
    }
