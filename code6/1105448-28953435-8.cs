    var productList = DataProvider.GetCombinedProductInfoFromData(dataFromXml);
    foreach (var product in productList)
    {
        Console.WriteLine(product);
        if (product.Categories == null)
        {
            continue;
        }
        foreach (var category in product.Categories)
        {
            Console.WriteLine("\t{0}", category);
            if (category.Issues == null)
            {
                continue;
            }
            foreach (var issue in category.Issues)
            {
                Console.WriteLine("\t\t{0}", issue);
            }
        }
    }
