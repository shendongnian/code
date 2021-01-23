    var result = collection.AsQueryable<USER>()
                           .AsExpandable()
                           .Where(where_clause)
                           .Select(c => new { c.ID, c.COMPANYNAME, c.EMAIL 
                           }).Take(100).ToList();
