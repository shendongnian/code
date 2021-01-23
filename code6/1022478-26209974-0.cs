    List<Product> products = new List<Product>();
    products.Add(new Product { ProductId = "abc", Type = "Normal", Status = "1" });
    products.Add(new Product { ProductId = "def",  Type = "Normal", Status = "2"  });
    products.Add(new Product { ProductId = "ghi",  Type = "VIP" , Status = "3" });
    products.Add(new Product { ProductId = "jkl",  Type = "Group", Status = "1" });
    IEnumerable<string> groupedProducts = products.GroupBy(product => product.Type)
                                                  .Select(grouping => string.Format("Type: {0} Count: {1}", grouping.Key, grouping.Count())); 
    foreach (var groupedProduct in groupedProducts)
    {
        Console.WriteLine(groupedProduct);
    }
