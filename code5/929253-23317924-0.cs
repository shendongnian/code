     var query = repository.Entries
                           .Where(p => Specialty == null || p.Sub == Specialty);
            
     switch (sortOrder)
     {
        case "Case":
            query = query.OrderBy(p => p.Case);
            break;
        case "Timestamp":
            query = query.OrderBy(p => p.TimeStamp);
            break;
        case "Origin":
            query = query.OrderBy(p => p.Origin);
            break;
     **SNIP**
    var Entry = query.Skip((page - 1) * pagesize)
                      .Take(pagesize)
                      .ToList() //You probably need this here
