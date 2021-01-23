    var products = container.Execute<Product>(new Uri()), "GET"); // You can pass the Uri as what you want
    foreach(var p in products)
    {
        Console.WriteLine("{0} {1} {2}", p.Name, p.Price, p.Category);
    }   
