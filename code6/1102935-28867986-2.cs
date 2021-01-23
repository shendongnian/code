    public static void Main()
    {
        var hammerPrice = new Price {BasePrice = 10, PercentMarkup = .15m};
            
        Console.WriteLine("{0:C} hammers will be sold for {1:C}, except on " + 
            "Sunday, when they will be {2:C}", hammerPrice.BasePrice, 
            hammerPrice.MarkedupPrice, hammerPrice.GetMarkedUpPrice(.1m));
        Console.WriteLine("Otherwise, items with a base price of $10.00 " + 
            "will be sold for {0:C}", Price.GetMarkedUpPrice(10, .2m));
    }
