    [XmlRoot("catalog")]
    public class Catalog
    {
        [XmlArray("items")] // note that I corrected 'term' to 'items'/'item'
        [XmlArrayItem("item", typeof(Item))]
        public Item[] item{ get; set; }
    }
