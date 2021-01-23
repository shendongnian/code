    var props = saleList.GetType().GetElementType().GetProperties();
    foreach (var sale in saleList)
    {
        foreach (var p in props)
        {
            Console.WriteLine(p.Name + "=" + p.GetValue(sale,null));
        }
        Console.WriteLine();
    }
