    public IQueryable<Entity> GetMethod(params bool[] parameters)
    {        
         bool anyIsTrue = parameters.Any(p => p); //.Any() will do, but just for clarification
         bool anyIsFalse = pramaters.Any(p => !p);
        
         bool allAreTrue = parameters.All(p => p);
         bool allAreFalse = parameters.All(p => !p);
     
         //rest of logic
    }
