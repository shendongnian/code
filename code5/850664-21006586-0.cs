    // Note: assuming that PriceMethod is an enum.
    var costs = Dictionary<PriceMethod, decimal>();
    foreach (PriceMethod priceMethod in (PriceMethod[])Enum.GetValues(typeof(PriceMethod)))
    {
        // Assuming AP is a decimal, since if it's an int there might be rounding issues.
        costs[priceMethod] = ((int)priceMethod * AP) / 100;
    }
