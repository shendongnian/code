        // http://stackoverflow.com/questions/870293/can-i-make-xmlserializer-ignore-the-namespace-on-deserialization
        // helper class to ignore namespaces when de-serializing
        public class NamespaceIgnorantXmlTextReader : System.Xml.XmlTextReader
        {
            public NamespaceIgnorantXmlTextReader(System.IO.TextReader reader) : base(reader) { }
            public override string NamespaceURI
            {
                get
                { //return ""
                    // string nam = base.Name;
                    // Console.WriteLine(this.Name);
                    // Console.WriteLine(this.LocalName);
                    if (StringComparer.InvariantCultureIgnoreCase.Equals(this.Name, "office:version"))
                    {
                        return "";
                    }
                    // Console.WriteLine(nam);
                    return base.NamespaceURI;
                }
            }
        }
