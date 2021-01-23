        [XmlRoot("Root")]
        public class AddressDetails
        {
            [XmlAttribute]
            public int LineNumber { get; set; }
            [XmlAttribute]
            public int LinePosition { get; set; }
            ...
        }
    This of course can be done by subclassing.
