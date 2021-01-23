    public class XmlExtendableReader : XmlWrappingReader
    {
        private bool _ignoreNamespace { get; set; }
        public XmlExtendableReader(TextReader input, XmlReaderSettings settings, bool ignoreNamespace = false)
        : base(XmlReader.Create(input, settings))
        {
            _ignoreNamespace = ignoreNamespace;
        }
        public override string NamespaceURI
        {
            get
            {
                return _ignoreNamespace ? String.Empty : base.NamespaceURI;
            }
        }
    }
