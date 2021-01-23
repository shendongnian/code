    class Program
    {
        static void Main(string[] args)
        {
            var quote = new StockQuote("test", "6.1e-7");
            string data = JsonConvert.SerializeObject(quote);
            Console.WriteLine(data);
            StockQuote quoteTwo = JsonConvert.DeserializeObject<StockQuote>(data);
            Console.ReadLine();
        }
    }
    [JsonObject]
    public class StockQuote
    {
        //If you want to serialize the class into a Json, you will need the
        //JsonProperty attributes set
        [JsonProperty(PropertyName="name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName="price")]
        public decimal Price { get; set; }
        [JsonConstructor]
        public StockQuote(string name, string price)
        {
            this.Name = name;
            this.Price = Decimal.Parse(price, System.Globalization.NumberStyles.Float);
        }
    }
