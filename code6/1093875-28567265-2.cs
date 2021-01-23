    from o in orders
    where o.Supplier != null &&
          o.ProductTitle != null &&
          o.Code != null &&
          o.MaxPrice != null
    group o by new { o.ProductTitle, o.Code } into g
    select new
    {
        ProductTitle = g.Key.ProductTitle,
        Code = g.Key.Code,
        MaxPrice = g.Max(x => x.MaxPrice)
    };
