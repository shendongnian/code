    [Serializable]
    [XmlRoot("one")]
    public class OnePrice
    {
        [XmlAttribute("price")]
        public int price { get; set; }
    }
    [Serializable]
    [XmlRoot("two")]
    public class TwoPrice
    {
        [XmlAttribute("price")]
        public int price { get; set; }
    }
    [Serializable]
    [XmlRoot("three")]
    public class ThreePrice
    {
        [XmlAttribute("price")]
        public int price { get; set; }
    }
    [Serializable]
    [XmlRoot("products")]    
    public class Product
    {        
        [XmlAttribute("grand-total")]
        public int GrandTotal { get; set; }
        [XmlElement("one")]
        public OnePrice OnePrice { get; set; }
        [XmlElement("two")]
        public TwoPrice TwoPrice { get; set; }
        [XmlElement("three")]
        public ThreePrice ThreePrice { get; set; }
    }
