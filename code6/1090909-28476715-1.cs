    public IEnumerable<Product> GetInitialProducts()
    {
            List<Product> list = new List<Product>
            {
                new Product{Name = "First", Description = "descr1", Id = 1, ListPrice = 1.1F},
                new Product{Name = "Second", Description = "descr2", Id = 2, ListPrice = 2.2F},
            };
                return list;
    }
