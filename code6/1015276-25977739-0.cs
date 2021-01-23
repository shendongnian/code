    [Fact]
    [AutoRollback]
    public void AddProductTest_AddsProductAndRetrievesItFromTheDatabase()
    {
        // connect to your test db
        YourDbContext dbContext = new YourDbContext("TestConnectionString")
        dbContext.Products.Add(new Product(...));
        // get the recently added product (or whatever your query is)
        var result = dbContext.Single();
        // assert everything saved correctly
        Assert.Equals(...);
    }
