    List<Product> products = new List<Product>()
    {
        new Product{name = "ProductA",versions = new List<Product.Version>()
        {
            new Product.Version{vers = 1},
            new Product.Version{vers = 2},
            new Product.Version{vers = 3}
        }},
        new Product{name = "ProductB",versions = new List<Product.Version>()
        {
            new Product.Version{vers = 2.1},
            new Product.Version{vers = 2.2},
            new Product.Version{vers = 2.3}
        }}                
    };
    comboBox2.DataSource = products;
