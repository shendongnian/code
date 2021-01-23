    IQueryable<whatever> newQuery;
    switch (caseSwitch)
    {
     case 1: newQuery = query.Select(i => new { Name = i[9], ... }); break;
     case 2: newQuery = query.Select(i => new { Name = i[6], ... }); break;
    }
    
