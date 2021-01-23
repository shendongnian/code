    class Entry{
       [XmlAttribute("key")]
       public string key {get;set;}
       [XmlText]
       public string entry{get;set;}
    }
    
    [Serializable]
    [XmlRoot(ElementName = "xml")]
    public class MyXml
    {
       [XmlArray(ElementName = "metadata")]
       [XmlArrayItem(ElementName = "entry")]
       public List<Entry> Metadata { get; set; }
    }
