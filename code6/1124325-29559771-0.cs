    public class Root
    {
        [XmlIgnore]
        public string Text { get; set; }
        [XmlAnyElement]
        public XmlElement TextElement
        {
            get
            {
                var x = new XmlDocument();
                x.LoadXml(string.Format("<Text>{0}</Text>", Text));
                return x.DocumentElement;
            }
            set { Text = value.InnerXml; }
        }
    }
