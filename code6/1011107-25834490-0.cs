    Database.SetInitializer(new Wb1.Model.ProductsDatabaseInitializer());
    using (var dbContext = new Wb1.Model.ETestContext())
    {
        dbContext.Database.Initialize(true);
    }
