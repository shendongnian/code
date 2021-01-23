    [XmlRoot("browser")]
    public class Browser
    {
        private readonly List<BrowserType> _items = new List<BrowserType>();
        [XmlElement("firefox", typeof(Firefox))]
        [XmlElement("chrome", typeof(Chrome))]
        [XmlElement("ie", typeof(IE))]
        public List<BrowserType> Items { get { return _items; } }
    }
    public class BrowserType
    {
        [XmlAttribute("company")]
        public string Company { get; set; }
    }
    public class Firefox : BrowserType
    {
    }
    public class Chrome : BrowserType
    {
    }
    public class IE : BrowserType
    {
    }
