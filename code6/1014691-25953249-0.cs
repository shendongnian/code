    for (int i = 0; i < saleList.Lenght; i++)
    {
        OO_WebService.Sale sale = saleList[i];
        Console.WriteLine(sale.PurchaseDate);
        Console.WriteLine(sale.Location);
    }
