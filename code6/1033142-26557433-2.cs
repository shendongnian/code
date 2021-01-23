    [XmlRoot("root")]
    public class Root
    {
        [XmlElement("parameter1")]
        public int Parameter1{ get; set; }
        [XmlElement("itemLists")]
        public List<ItemList> ItemLists{ get; set; }
    }
    public class ItemList
    {
        [XmlElement("parameter2")]
        public List<ItemList> Parameter2{ get; set; }
        [XmlElement("items")]
        public List<Item> Items{ get; set; }
    }
    public class Item
    {
        [XmlElement("parameter3")]
        public string Parameter3{ get; set; }
    }
