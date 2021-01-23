    public class ReplaceNsXmlReader : XmlWrappingReader
    {
        private readonly string replacementNs;
        public ReplaceNsXmlReader(XmlReader reader, string replacementNs)
            : base(reader)
        {
            //
            // NOTE: String.Intern is here needed for the XmlSerializer
            // that will be using this reader to deserialize correctly
            //
            this.replacementNs = String.Intern(replacementNs);
        }
        public override string NamespaceURI
        {
            get => replacementNs;
        }
    }
