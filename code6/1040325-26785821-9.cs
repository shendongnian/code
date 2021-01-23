    [XmlRoot("ITEM_REPLY")]
    public class ItemAvlReply
    {
        [XmlElement("TRAN_ID")]
        public string TRAN_ID { get; set; }
        [XmlElement("REPLY_CODE")]
        public string REPLY_CODE { get; set; }
        [XmlElement("UNIT_PRICE")]
        public string UNIT_PRICE { get; set; }
        [XmlElement("SUP_LOCS")]
        public SupplierLocations SUP_LOCS;
        [XmlElement("MESSAGE")]
        public string MESSAGE { get; set; }
        [XmlElement("QTY_BREAKS")]
        public string QTY_BREAKS { get; set; }
    }
    public class SupplierLocations
    {
        [XmlElement("SUP_LOC")]
        public List<SupplierLocation> SUP_LOC;
    }
    public class SupplierLocation
    {
        [XmlElement("SUP_LOC_ID")]
        public string SUP_LOC_ID { get; set; }
        [XmlElement("COUNTRY_ID")]
        public string COUNTRY_ID { get; set; }
        [XmlElement("QTY_AVL")]
        public string QTY_AVL { get; set; }
        [XmlElement("ITEM_UOM")]
        public string ITEM_UOM { get; set; }
    }
