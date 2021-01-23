    [Serializable()]
    [XmlRoot("root")]
    public class XMLObj: IDisposable
    {
        [XmlElement("block")]
        public List<XMLnode> nodes{ get; set; }
    
        public XMLObj() { }
    
        public void Dispose()
        {
            nodes.ForEach(n => n.Dispose());
            nodes= null;
    
            GC.SuppressFinalize(this);
        }
    }
