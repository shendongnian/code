    string csvString1 = "TestProduct;15.50;5";
    string csvString2 = "TestProduct;15.50;5;0.25";
    Purchase p1 = csvString1.GetPurchaseObject();
    Purchase p2 = csvString2.GetPurchaseObject();
    if (p1 is DiscountPurchase)
    {
        Console.WriteLine("p1 is a DiscountPurchase item");
    }
    else
    {
        Console.WriteLine("p1 a Purchase item");
    }
    if (p2 is DiscountPurchase)
    {
        Console.WriteLine("p2 is a DiscountPurchase item");
    }
    else
    {
        Console.WriteLine("p2 a Purchase item");
    }
