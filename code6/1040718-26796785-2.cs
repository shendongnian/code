    public class Wrapper
    {
        public Item item;
    }
    public class Item
    {
        public string icon { get; set; }
        public string icon_large { get; set; }
        public int id { get; set; }
        public string type { get; set; }
        public string typeIcon { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public GrandExchange current { get; set; }
        public GrandExchange today { get; set; }
        public bool members { get; set; }
        public GrandExchange day30 { get; set; }
        public GrandExchange day90 { get; set; }
        public GrandExchange day180 { get; set; }
    }
    public class GrandExchange
    {
        public string trend { get; set; }
        public string price { get; set; }
    }
