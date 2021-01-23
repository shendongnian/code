    public class Document
    {
        [XmlElement("name")]
        public string Name { set; get; }
        [XmlElement("open")]
        public int Open { set; get; }
        [XmlElement("Placemark")]
        public List<Placemark> Placemarks { set; get; }
    }
