    public static class NameSpaces
    {
        static readonly XmlSerializerNamespaces namespaces;
        static NameSpaces()
        {
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", NameSpaces.Default);
            namespaces.Add("xsi", NameSpaces.Xsi);
            namespaces.Add("etd", NameSpaces.Etd);
            namespaces.Add("zzu", NameSpaces.Zzu);
        }
        public static XmlSerializerNamespaces XmlSerializerNamespaces
        {
            get
            {
                return namespaces;
            }
        }
        public const string Default = "http://crd.gov.pl/wzor/2014/12/08/1887/";
        public const string Etd = "http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2011/06/21/eD/DefinicjeTypy/";
        public const string Xsi = "http://www.w3.org/2001/XMLSchema-instance";
        public const string Zzu = "http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2011/10/07/eD/ORDZU/";
        public const string SchemaLocation = "http://crd.gov.pl/wzor/2014/12/08/1887/ http://crd.gov.pl/wzor/2014/12/08/1887/schemat.xsd";
    }
    [XmlRoot("Deklaracja", Namespace = NameSpaces.Default)]
    public class EPIT11V21
    {
        public EPIT11V21() {
            this.Zalaczniki = string.Empty;
        }
        public EPIT11V21(int XPDeclarationID) : this()
        {
            this.Pouczenie = "Za uchybienie obowiązkom płatnika grozi odpowiedzialność przewidziana w Kodeksie karnym skarbowym.";
        }
        [XmlAttribute("schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string XSDSchemaLocation
        {
            get
            {
                return NameSpaces.SchemaLocation;
            }
            set {
                // Do nothing - fake property.
            }
        }
        public Podmiot1PIT11V21 Podmiot1 = new Podmiot1PIT11V21();
        public String Pouczenie { get; set; }
  
        public String Zalaczniki { get; set; }
        [XmlNamespaceDeclarations]
        public XmlSerializerNamespaces xmlsn
        {
            get
            {
                return NameSpaces.XmlSerializerNamespaces;
            }
            set { 
                // Do nothing - fake property.
            }
        }
    }
    public class Podmiot1PIT11V21
    {
        public Podmiot1PIT11V21() { }
        [XmlAttribute("rola")]
        public string rola = "Płatnik";
        [XmlElement("OsobaNieFizyczna", Namespace = NameSpaces.Etd)]
        public OsobaNiefizycznaPIT11V21 OsobaNieFizyczna = new OsobaNiefizycznaPIT11V21();
    }
    public class OsobaNiefizycznaPIT11V21
    {
        public OsobaNiefizycznaPIT11V21() { }
        public string NIP = "0000000000";
        public string PelnaNazwa = "XXXXXXXX";
    }
