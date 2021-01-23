    ProductDTO dto = null;
    var productsGrouped = session.QueryOver<Product>()
        // let's fill projection list with all the SUM, COUNT but als WITH ALIAS
        .Select(Projections.ProjectionList()
            .Add(Projections.Group<Product>(p => p.Category)
                .WithAlias(() => dto.Category))
            .Add(Projections.Avg<Product>(p => p.UnitPrice)
                .WithAlias(() => dto.UnitPrice))
            .Add(Projections.Sum<Product>(p => p.UnitsOnStock)
                .WithAlias(() => dto.UnitsOnStock))
            .Add(Projections.RowCount()
                .WithAlias(() => dto.RowCount))
        )
        // here we instruct NHibernate to convert projection into our object DTO
        .TransformUsing(Transformers.AliasToBean<ProductDTO>())
        // fully typed result
        .List<ProductDTO>();
    // now it is fully qualified object
    foreach (var product in productsGrouped)
    {
        Console.WriteLine(product.Category);  //Dont Work
    }
