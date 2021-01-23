    public class Product
    {
        [JsonProperty("product_id")]
        public int ProductId { get; set; }
        [JsonProperty("product_name")]
        public string ProductName { get; set; }
        [JsonProperty("stock")]
        public int Stock { get; set; }
    }
