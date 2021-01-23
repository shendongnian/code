    public partial class StandardPageLeftContentAdditionalSection
    {
        public string SectionTitle { get; set; }
    
        [XmlElement("Link")]
        public StandardPageLeftContentAdditionalSectionLink[] Link { get; set; }
    }
