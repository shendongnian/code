    public class Craftable
    {
        public string currency { get; set; }
        public int value { get; set; }
        public int last_update { get; set; }
        public double difference { get; set; }
    }
    
    public class Tradable
    {
        public List<Craftable> Craftable { get; set; }
    }
     
    public class Prices
    {
        public Tradable Tradable{ get; set; }
    }
    
    public class Items
    {
        public List<int> defindex { get; set; }
        public Prices prices { get; set; }
    }
     
    public class Response
    {
        public int success { get; set; }
        public int current_time { get; set; }
        public double raw_usd_value { get; set; }
        public string usd_currency { get; set; }
        public int usd_currency_index { get; set; }
        public Items items { get; set; }
    }
    
    public class RootObject
    {
        public Response response { get; set; }
    }
