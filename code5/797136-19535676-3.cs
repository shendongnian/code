    graphClient.Client
        .Match("(c:Category)")
        .Where((Category c) => c.UniqueId == someGuidVariable)
        .Return(c => c.As<Category>())
        .Results
        .Single();
