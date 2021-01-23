    public class Item
    {
        public string @Url {get; set;}
        public string Name {get; set;}
        public double Price {get; set;}
        public Item(string @url, string name, double price)
        {
            this.Url = url;
            this.Name = name;
            this.Price = price;
        }
    }
