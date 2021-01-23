    public class Product
    {
       public Product()
       {
          dependProduct = new List<Product>();
       }
      
        public string Title { get; set; }
        public int Cost { get; set; }
        public List<Product> dependProduct { get; set; }
    }
