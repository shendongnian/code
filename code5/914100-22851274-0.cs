    Product product = new Product
    {
        Name = "Dog food",
        Price = 9.95,
        Manufacturer =
        {
            Name = "Dog food producer"
            Location = "Some location"
        },
        SimilarProducts =
        {
            new Product { Name = "Cat food" },
            new Product { Name = "Bird food", Price = 5.50},
            new Product 
            { 
                Name = "Guinea Pig food", 
                Price = 5.50
                SimilarProducts = 
                { 
                    new Product { Name = "Guinea Pig shampoo" }, 
                    new Product { Name = "Guinea Pig toofpaste" }
                },
            },
        },
    }
