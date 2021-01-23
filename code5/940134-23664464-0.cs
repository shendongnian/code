    public class FormatterSettings
    {
        [XmlAttribute("Range")]
        public CharacterRange CharRange { get; set; }
    
        [XmlAttribute("Restriction")]
        public CharacterRangeRestriction RestrictRange { get; set; }
    
        [XmlAttribute("Padding")]
        public int Padding { get; set; }
    
        [XmlAttribute("DateFormat")]
        public string DateFormat{ get; set; }
    }
