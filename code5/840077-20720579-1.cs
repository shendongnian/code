    IEnumerable<Product> products = CreateProducts();
    Params param = new Params { Val = "ABC"};
    Func<Params, IEnumerable<Product>, IEnumerable<Product>> filterFunc = 
        (p, r) => r.Where(x => x.Sku == p.Val);
    IEnumerable<Product> prods = filterFunc(param, products);
    
    private static IEnumerable<Product> CreateProducts() 
    {
        return new Products[] {
            new Product{
                Price = 25.00,
                Sku = "ABC"
            },
            new Product{
                Price = 134.00,
                Sku = "DEF"
            },
        };
    }
