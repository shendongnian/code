    [Serializable()]
    [System.Xml.Serialization.XmlRoot(ElementName = "Root", Namespace = "http://whatever")]
    public class ResponseClass
    {
        [System.Xml.Serialization.XmlElement("Child1")]
        public OperationRequest OperationRequest { get; set; }
    
        [System.Xml.Serialization.XmlElement("ItemList")]
        public ItemList ItemList { get; set; }
    }
    
    [Serializable()]
    [System.Xml.Serialization.XmlRoot(ElementName = "ItemList", Namespace = "http://whatever")]
    public class ItemList
    {
        [System.Xml.Serialization.XmlElement("Item")]
        public Item[] Items { get; set; }
    
        [System.Xml.Serialization.XmlElement("Element1")]
        public int Element1 { get; set; }
    }
