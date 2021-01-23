    var results = 
    from row in lDTSalesOrder
    group row by new { SKU = row.Field<string>("SKU"), UnitPrice = row.Field<string>("UnitPrice") } into grp
    orderby grp.Key.SKU
    select new
    {
        SKU = grp.Key.SKU,
        Quantity = grp.Sum(r => r.Field<double>("Quantity")),
        UnitPrice = grp.Key.UnitPrice,
        LinePrice = grp.Sum(r => r.Field<double>("LinePrice"))
    };
