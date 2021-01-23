    public class Listings
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    
        public List<Buy> Buys { get; private set; }
    
        public Listings()
        {
            Buys = new List<Buy>();
        }
    }
    public class Buy
    {
        [JsonProperty(PropertyName = "listings")]
        public int Listings { get; set; }
    
        [JsonProperty(PropertyName = "unit_price")]
        public int UnitPrice { get; set; }
    
        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }
    }
