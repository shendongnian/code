    class Program
    {
        static void Main(string[] args)
        {
            string json = @"[{""ID"":""1"",""ProductName"":""Canon""},{""ID"":""2"",""ProductName"":""HP""}]";
            IEnumerable<Product> result =  JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
        }   
    }
    class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
    }
