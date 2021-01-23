    var priceGroups = oPricePlan.Prices
        .OrderBy(p => p.Rate)  // order by rate ascending
        .GroupBy(p => p.Rate)  // group by rate
        .First()  // use the lowest price-rate group only
        .Take(2); // change 2 to 1 if you only want to modify one price in this min-group
    foreach (Price price in priceGroups)
    {
        price.Rate = 0;
        price.Free = true;
    }
