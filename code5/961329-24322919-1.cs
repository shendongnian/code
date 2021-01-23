    public class Product
    {
        public Product()
        {
            // var lastProduct = (Product)Cache["LastProduct"];
            // Set default value here
        }
        public int Id { get; set; }
        public string Sku { get; set; }
        public int PriceId { get; private set; }
    
        public virtual Price Price { get; set; }
    }
