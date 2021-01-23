    public class rgInventoryItem
    {
        public string id { get; set; }
        public string classid { get; set; }
    }
    public class rgDescription
    {
        public string classid { get; set; }
        public string market_name { get; set; }
    }
    public class InventoryResponse
    {
        public Dictionary<string, rgInventoryItem> rgInventory { get; set; }
        public Dictionary<string, rgDescription> rgDescriptions { get; set; }
    }
