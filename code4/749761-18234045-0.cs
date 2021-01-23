    class Market
        {
          [JsonProperty("success")]
          public int Success { get; set; }
          [JsonProperty("return")]
          public Container Container { get; set; }
          
        }
        class Container
        {
          [JsonProperty("sellorders")]
          public List<SellOrder> SellOrders { get; set; }
    
          [JsonProperty("buyorders")]
          public List<BuyOrder> BuyOrders { get; set; }
        }
    
        public class SellOrder
        {
          [JsonProperty("sellprice")]
          public decimal SellPrice { get; set; }
    
          [JsonProperty("quantity")]
          public decimal Quantity { get; set; }
    
          [JsonProperty("total")]
          public decimal Total { get; set; }
        }
    
        public class BuyOrder
        {
          [JsonProperty("buyprice")]
          public decimal BuyPrice { get; set; }
    
          [JsonProperty("quantity")]
          public decimal Quantity { get; set; }
    
          [JsonProperty("total")]
          public decimal Total { get; set; }
    }
