    Container ctx = new Container();
    foreach (var productFamily in ctx.ProductFamilies.Expand("Products"))
    {
        Console.WriteLine("\t{0}-{1}: {2}", 
            productFamily.ID, productFamily.Name, productFamily.Description);
        foreach (var product in productFamily.Products)
        {
            Console.WriteLine("\t\t{0}-{1}", 
                product.ID, product.Name);
        }
    }
