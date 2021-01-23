    class Program
        {
            static void Main(string[] args)
            {
               
                MyXml  xml  = new MyXml();
                xml.Metadata.Add( new Entry(){Key = "test","content"});
            }
    
    
        }
        [Serializable]
        [XmlRoot(ElementName = "xml")]
        public class MyXml
        {
            [XmlArray(ElementName = "metadata")]
            [XmlArrayItem(ElementName = "entry")]
            public List<Entry> Metadata { get; set; }
        }
