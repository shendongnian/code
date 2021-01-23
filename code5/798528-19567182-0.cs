    public static void Main()
    {
        GetAtts(xml);
    }
    public static Atts GetAtts(string xml)
    {
        Atts atts = new Atts();
        XDocument doc = XDocument.Parse(xml);
        if (doc.Root.Element("Event") != null)
            atts.datetime = doc.Root.Element("Event").Attribute("DateTime").Value;
        //...
        foreach (XElement ele in doc.Descendants("Network"))
            atts.accesspointid.Add(ele.Attribute("AccessPointID").Value);
        
        return atts;
    }
    public class Atts
    {
        public string datetime { get; set; }
        public string role { get; set; }
        private List<string>_accesspointid = new List<string>();
        public List<string> accesspointid { get { return _accesspointid; } set { _accesspointid = value; } }
        public List<string> _participantid = new List<string>();
        public List<string> participantid { get { return _participantid; } set { _participantid = value; } }
        public string participantname { get; set; }
    }
