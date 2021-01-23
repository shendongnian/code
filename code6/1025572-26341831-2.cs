    private ExcelQueryable<Thing> ExcelQueryableOfThing()
    {
        var things = new List<Thing>
        {
            new Thing
            {
                Id = "1",
                Name = "Adam"
            },
            new Thing
            {
                Id = "1",
                Name = "Eva"
            }
        }
        .AsQueryable();
    
        Mock<IQueryProvider> queryProvider = new Mock<IQueryProvider>();
        queryProvider
            .Setup(p => p.CreateQuery<Thing>(It.IsAny<Expression>()))
            .Returns(() => things);
    
        Expression expression = Expression.Constant((object)things);
    
        return new ExcelQueryable<Thing>(queryProvider.Object, expression);
    }
