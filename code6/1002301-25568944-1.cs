    Parallel.ForEach(Settings.ProdCostsAndQtys, c =>
    {
        SimplifiedPricing value;
        if (simplifiedPricingLookup.TryGetValue(new MyKey(c.improd, c.pplist), out value))
        {
            c.pricecur = value.PPP01;
            c.priceeur = value.PPP01;
        }
    });
