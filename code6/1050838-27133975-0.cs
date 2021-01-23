    [Serializable]
    [XmlRoot("report")]
    public class report
    {
        [XmlAnyElement("residential")]
        public XmlElement[] residential;
        [XmlElement("residentialCaseHeader")]
        public residentialCaseHeader residentialCaseHeader;
    }
