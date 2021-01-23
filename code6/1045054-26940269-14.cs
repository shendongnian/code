    void Main()
    {
    
        var targetSalePrice = 1.5;
        var targetProductId = 2;
    
        var Products = new List<Product>() { new Product()
                                               { Id = 2,
                                                 Sales = new List<Tuple<string, double>>()
                                                { new Tuple<string,double>("actual", 1.6) } }
                                            };
    
    
    // Our default will set saleAmount to string.Empty if nothing is found in Products.
    var defProduct = new Product() { Id = -1, Sales = new List<Tuple<string, double>>()
                                      { new Tuple<string,double>("faux string.Empty", 0.0) }};
    
    var productSale =
    
    Products.Where(p => p.Id == targetProductId 
                       && p.Sales.Any (s => s.Item2 == targetSalePrice ) )
            .DefaultIfEmpty( defProduct )
            .First ()
            .Sales.First ()
            .Item1;
    
        productSale.Dump(); // outputs the string "faux string.Empty" from the faux default.
    
    }
    
    // Define other methods and classes here
    
    
    public class Product
    {
        public int Id { get; set; }
        public List<Tuple<string, double>> Sales { get; set; }
    }
