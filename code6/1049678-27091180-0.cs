    var query = db.Agents;
    
    if (Id != 0) 
    { 
       query = query.Where(x => x.LocationId == Id)
    }
    
    if (!string.IsNullOrWhitespace(b))
    {
       query = query.Where(x => x.LocationName == b)
    }
    ...
