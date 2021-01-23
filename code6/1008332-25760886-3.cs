    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class punten
    {
        [System.Xml.Serialization.XmlElementAttribute("Placemark")]
        public puntenPlacemark[] Placemark { get; set; }
    }
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class puntenPlacemark
    {
        public byte OBJNR { get; set; }
        public string OBJOMSCHRI { get; set; }
        public string LANGEOMSCH { get; set; }
        public string coordinates { get; set; }
    }
