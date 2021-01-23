    // list to keep tack of found prices
    var prices = new List<decimal>();
    foreach(Pet pet in pets)
    {
        if(prices.Contains(pet.Price.Value))
            // price was found - set this one to null
            pet.Price = null;
        else
            // add to the list of "found" prices
            prices.Add(pet.Price.Value);
    }
