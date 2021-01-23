    public Category GetOrCreateCategoryByName(string name)
    {
        return graphClient.Client
            .WithParams(new {
                name,
                newIdIfRequired = Guid.NewGuid()
            })
            .Merge("(c:Category { Name = {name})")
            .OnCreate("c")
            .Set("c.UniqueId = {newIdIfRequired}")
            .Return(c => c.As<Category>())
            .Results
            .Single();
    }
