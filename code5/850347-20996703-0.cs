    // Create a dictionary of pairs of 'strings' (the item) and 'ints' (the prices)
    Dictionary<string, int> pricesByItem = new Dictionary<string, int>();
    
    // Add items and their prices.
    pricesByItem.add("Sandwhich", 3);
    pricesByItem.add("Hamburger", 4);
    pricesByItem.add("Cheese", 5);
    // Get the price of an item
    int priceOfASandwhich = pricesByItem["Sandwhich"];
    Console.WriteLine(priceOfASandwhich);
