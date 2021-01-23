    public class Podmiot1PIT11V21
    {
        public Podmiot1PIT11V21(){}
        [XmlAttribute("rola")]
        public string rola = "Płatnik";
        [XmlElement("OsobaNieFizyczna", Namespace = "http://crd.gov.pl/xml/schematy/dziedzinowe/mf/2011/06/21/eD/DefinicjeTypy/")]
        public OsobaNiefizycznaPIT11V21 OsobaNieFizyczna = new OsobaNiefizycznaPIT11V21();
    }
