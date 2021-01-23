    [Serializable]
    public class XArticle
    {
        [XmlIgnore]
        public List<XBlock> Blocks { get; set; }
    
    
        [XmlIgnore]
        public List<XElt> Elts { get; set; }
        [XmlElement(Type = typeof(XBlock), ElementName = "Block")]
        [XmlElement(Type = typeof(XElt), ElementName = "Elt")]
        public List<object> Elements
        {
            get
            {
                return Blocks.Select(b => new KeyValuePair<string, object>(b.Elt.Text, b))
                    .Concat(Elts.Select(e => new KeyValuePair<string, object>(e.Text, e)))
                    .OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value).ToList();
            }
            set { }
        }
