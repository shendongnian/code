    var prices = new SortedSet<decimal>("1.2,3,4.6,7,8,23".Split(',').Select(decimal.Parse));
    foreach (var price in prices)
    {
        bool isMin = price == prices.Min;
        bool isMax = price == prices.Max;
        // ...
    }
