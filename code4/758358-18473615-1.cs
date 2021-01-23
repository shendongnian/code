    public class Item
    {
        private string @Url {get; set;}
        private string Name {get; set;}
        private double Price {get; set;}
        public Item(string @url, string name, double price)
        {
            this.Url = url;
            this.Name = name;
            this.Price = price;
        }
    }
