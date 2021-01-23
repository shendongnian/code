    [XmlRootAttribute("RootNode")]
    public class RootNode
    {
        [XmlElement("Collection")]
        public Collection[] CollectionBag { get; set; }
    }
