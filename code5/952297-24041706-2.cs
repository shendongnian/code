    private static IQueryable<TestObject> GetFilteredQuery(Guid[] componentIds, 
                                                           Guid[] productIds)
    {
        var candidates = ModelQuery
             .Query<TestObject>()
             .Where(componentIds.Contains(
                             t.ComponentId) || productIds.Contains(t.ProductId))
             .ToList();// Need to materialize
    
        var guidPairs = componentIds.Zip(productIds, 
              (c, p) => new {ComponentId = c, ProductId = p});
    
        return candidates
          .Join(guidPairs, 
                c => new {ComponentId = c.ComponentId, ProductId = c.ProductId}, 
                gp => gp, 
                (c, gp) => c)
          .AsQueryable();
    }
