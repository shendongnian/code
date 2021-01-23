    internal class WowAuction
    {
    
        [JsonProperty("realm")]
        public Realm Realm { get; set; }
    
        [JsonProperty("auctions")]
        public Auctions Auctions { get; set; }
    }
    
    
    internal class Realm
    {
    
        [JsonProperty("name")]
        public string Name { get; set; }
    
        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
     
    internal class Auctions
    {
    
        [JsonProperty("auctions")]
        public Auction[] Auctions { get; set; }
    }
    
    internal class Auction
    {
    
        [JsonProperty("auc")]
        public int Auc { get; set; }
    
        [JsonProperty("item")]
        public int Item { get; set; }
    
        [JsonProperty("owner")]
        public string Owner { get; set; }
    
        [JsonProperty("ownerRealm")]
        public string OwnerRealm { get; set; }
    
        [JsonProperty("bid")]
        public int Bid { get; set; }
    
        [JsonProperty("buyout")]
        public int Buyout { get; set; }
    
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    
        [JsonProperty("timeLeft")]
        public string TimeLeft { get; set; }
    
        [JsonProperty("rand")]
        public int Rand { get; set; }
    
        [JsonProperty("seed")]
        public int Seed { get; set; }
    
        [JsonProperty("context")]
        public int Context { get; set; }
    }
