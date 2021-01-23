    ObjectFactory.Initialize(x =>
    {
        x.For(typeof(IUnitOfWork<>)).Use(typeof(UnitOfWork<>));
        x.Scan(scanner =>scanner.AddAllTypesOf(typeof(IDbContext)));
    });
