    var obj = JsonConvert.DeserializeObject<ActiveOrders>(json);
----
    public class ActiveOrders
    {
        public int success { get; set; }
        public Dictionary<string,Order> @return { get; set; }
    }
    public class Order
    {
        public string pair { get; set; }
        public string type { get; set; }
        public double amount { get; set; }
        public double rate { get; set; }
        public int timestamp_created { get; set; }
        public int status { get; set; }
    }
