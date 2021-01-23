        [XmlRoot("Shops")]
        public class XmlShops
        {
            [XmlElement("Shop",typeof(Shop))]
            public List<Shop> Shops { get; set; }
        }
    
        public class Shop
        {
            [XmlElement("Location")]
            public string Location { get; set; }
            [XmlElement("Id")]
            public string Id { get; set; }
    
            [XmlArray("ShopLists")]
            [XmlArrayItem("ShopList",typeof(ShopList))]
            public List<ShopList> ShopLists { get; set;}
        }
    
        public class ShopList
        {
            [XmlElement("Area")]
            public string Area { get;set; }
            [XmlElement("Home")]
            public string Home { get;set; }
            [XmlElement("LicenseNo")]
            public string LicenseNo { get;set; }
        }
