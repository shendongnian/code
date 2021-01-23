    protected override void Seed(YPGOOSDataContext context)
    {
        GetCategories().ForEach(c => context.Categories.Add(c));
        GetProducts().ForEach(p => context.Products.Add(p));
        GetSizes().ForEach(s => context.Sizes.Add(s));
        GetQuantityBreaks().ForEach(q => context.QuantityBreaks.Add(q));
        GetStyles().ForEach(st => context.Styles.Add(st));
        GetStocks().ForEach(sto => context.Stocks.Add(sto));
        
        context.SaveChanges();
    }
