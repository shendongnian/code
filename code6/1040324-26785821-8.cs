    public class Order
    {
        [XmlElement("TransactionID")]
        public string TransactionId { get; set; }
        [XmlElement("OrderID")]
        public string OrderId { get; set; }
        [XmlElement("Items")]
        public ItemsContainer Items;
    }
    public class ItemsContainer
    {
        [XmlAttribute("Number")]
        public Int32 Number { get; set; }
        [XmlElement("Item")]
        public List<Item> Items;
    }
    public class Item
    {
        [XmlElement("ItemName")]
        public string ItemName { get; set; }
        [XmlElement("Color")]
        public string Color { get; set; }
    }
