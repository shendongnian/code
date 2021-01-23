        [Serializable]
        [XmlRoot("custom")]
        public class Custom 
        {
            [XmlElement("investment")]
            public string Investment { get; set; }
            [XmlElement("offtheplan")]
            public string Offtheplan { get; set; }
            [XmlElement("priceLower")]
            public Decimal? PriceLower { get; set; }
            [XmlElement("priceUpper")]
            public Decimal? PriceUpper { get; set; }
            [XmlElement("office")]
            public Office Office { get; set; }
        }
    
        [Serializable]
        public class Office
        {
            // temporary for debugging purposes:
            private string _officeName;
    
            [XmlElement("name")]
            public string Name { get; set; }
            [XmlElement("officeName")]
            public string OfficeName { get; set; }
            [XmlElement("addressL1")]
            public string Address1 { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string xml = @"<custom>
      <priceLower>999999</priceLower>
      <priceUpper>1000001</priceUpper>
      <investment>true</investment>
      <offtheplan>false</offtheplan>
      <office>
        <name>Melbourne Office</name>
        <officeName>Head Office</officeName>
      </office>
    </custom>";
    
                XmlSerializer s = new XmlSerializer(typeof(Custom));
    
                // Works fine without this
                //XmlAttributeOverrides attrOverrides = new XmlAttributeOverrides();
                //var attrs = new XmlAttributes();
                //var attr = new XmlElementAttribute();
                //attr.ElementName = "office";
                //attr.Type = typeof(Office);
                //attrs.XmlElements.Add(attr);
                //attrOverrides.Add(typeof(Office), "office", attrs);
                //s = new XmlSerializer(typeof(Custom), attrOverrides);
    
                using (StringReader reader = new StringReader(xml))
                {
                    Custom c = (Custom)s.Deserialize(reader);
                }
            }
        }
