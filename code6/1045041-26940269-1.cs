    void Main()
    {
    
        var Products = new List<Product>() { new Product() 
                                               { Id = 1, 
                                                 Sales = new List<Tuple<string, double>>() } } ;
        var product = new Product() { Id = 2 };
    
    // Our default will set saleAmount to string.Empty if nothing is found in Products.
    var defProduct = new Product() { Id = -1, Sales = new List<Tuple<string, double>>()
                                      { new Tuple<string,double>(string.Empty, 1.5) }};
    
    var productSale =
    
    Products.Where(p => p.Id == product.Id && p.Sales.Any (s => s.Item2 == 1.5 ) )
            .DefaultIfEmpty( defProduct )
            .First ()
            .Sales.FirstOrDefault (s => s.Item2 == 1.5 )
            .Item1;
    
    
        productSale.Dump();
    
    }
    
    // Define other methods and classes here
    
    
    public class Product
    {
        public int Id { get; set; }
        public List<Tuple<string, double>> Sales { get; set; }
    }
