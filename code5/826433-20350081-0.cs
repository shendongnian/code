    [Serializable]
    [XmlRoot("UtilityRateSummaries")]
    public class UtilityRateSummaries
    {
        [XmlElement("Utility")]
        public Utility Utility { get; set; }
        [XmlElement("Rate")]
        public Rate Rate { get; set; }
    }
    public class Utility
    {
        [XmlAttribute]
        public string UtilityId { get; set; }
        [XmlAttribute]
        public string UtilityName { get; set; }
    }
    public class Rate
    {
        [XmlAttribute]
        public string Id { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Sector { get; set; }
        [XmlAttribute]
        public string Metering { get; set; }
        [XmlAttribute]
        public string IsDefault { get; set; }
        [XmlAttribute]
        public string IsTimeOfUse { get; set; }
    }
