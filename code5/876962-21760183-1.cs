    public class RootObject
    {
        public Result Result { get; set; }
    }
    public class Result
    {
        public Client Client { get; set; }
    }
    public class Client
    {
        [JsonConverter(typeof(WrappedObjectConverter))]
        public List<Product> ProductList { get; set; }
        
        [JsonConverter(typeof(WrappedObjectConverter))]
        public string Name { get; set; }
        [JsonConverter(typeof(WrappedObjectConverter))]
        public string AddressLine1 { get; set; }
    }
    public class Product
    {
        [JsonConverter(typeof(WrappedObjectConverter))]
        public string Name { get; set; }
    }
