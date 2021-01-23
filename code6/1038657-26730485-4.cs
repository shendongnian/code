    using (var context = new DbContext()) 
    {
        context.Dogs.AddRange(dogs); // dogs being a list of dog entities
        context.Results.AddRange(results); // events being a list of results entities
    
        context.DogResults.AddRange(dogResults); // a list of the links
    }
