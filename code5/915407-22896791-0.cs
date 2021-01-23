    [JsonConverter(typeof(CustomConverter))]
    public class RootObject
    {
        public Dictionary<string, Order> Orders { get; set; }
        public string RecsInDB { get; set; }
        public string RecsOnPage { get; set; }
    }
    public class Order
    {
        [JsonProperty("orders.orderid")]
        public string OrderID { get; set; }
        [JsonProperty("entity.customerid")]
        public string CustomerID { get; set; }
        [JsonProperty("entity.entityid")]
        public string EntityID { get; set; }
    }
