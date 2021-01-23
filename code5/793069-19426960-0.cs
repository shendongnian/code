    [XmlTypeAttribute(AnonymousType = true)]
    public class PackIt<T>
    {
    
        [XmlElement("pack")]
        public List<T> objects { get; set; }
    
        public PackIt()
        {
             objects = new List<T>();
        }
    
    }
    PachIt<string> packIt = new PackIt<string>();
