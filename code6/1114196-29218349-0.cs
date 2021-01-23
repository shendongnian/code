    var queryResult = DatabaseContext.Table
        .Where(x => !x.IsDeleted)
        .OrderBy(i => i.ID)
        .Where(p => (
                p.PropertyOne.ToLower().Contains(query) ||
                p.PropertyTwo.ToLower().Contains(query) 
                ))
        .ToList();
    
    int count = queryResult.Count();  // now this will be a linq-to-objects query
    
    var returnData = queryResult
        .Skip(start).Take((length))
        .AsEnumerable();
