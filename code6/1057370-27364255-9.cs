    public class RootlessDataSetXmlWriter : ElementSkippingXmlWriter
    {
        private readonly string _dataSetName;
        public RootlessDataSetXmlWriter(TextWriter stream, string dataSetName)
            : base(stream, (e) => string.Equals(e, dataSetName, StringComparison.OrdinalIgnoreCase))
        {
            _dataSetName = dataSetName;
            this.Formatting = System.Xml.Formatting.Indented;
        }
        public RootlessDataSetXmlWriter(Stream stream, string dataSetName)
            : base(stream, (e) => string.Equals(e, dataSetName, StringComparison.OrdinalIgnoreCase))
        {
            _dataSetName = dataSetName;
            this.Formatting = System.Xml.Formatting.Indented;
        }
    }
    public class ElementSkippingXmlWriter : XmlTextWriter
    {
        private Predicate<string> _elementFilter;
        private int _currentElementDepth;
        private Stack<int> _sightedElementDepths;
        public ElementSkippingXmlWriter(TextWriter writer, Predicate<string> elementFilter)
            : base(writer)
        {
            _elementFilter = elementFilter;
            _sightedElementDepths = new Stack<int>();
        }
        public ElementSkippingXmlWriter(Stream stream, Predicate<string> elementFilter)
            : base(stream, Encoding.UTF8)
        {
            _elementFilter = elementFilter;
            _sightedElementDepths = new Stack<int>();
        }
        // Rest is as shown in the linked answer.
    } 
