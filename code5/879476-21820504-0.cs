        [Serializable()]
        [XmlRoot("SLVGeoZone-array")]
        public class SLVGeoZones
        {
            [XmlElement("SLVGeoZone")]
            public SLVGeoZone[] Cars { get; set; }
        }
