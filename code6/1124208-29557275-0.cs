    [Serializable]
    public class XArticle
    {
     
        [XmlElement(Type = typeof(XBlock), ElementName = "Block")]
        [XmlElement(Type = typeof(XElt), ElementName = "Elt")]
        public List<object> Elements { get; set; }
    
    }
