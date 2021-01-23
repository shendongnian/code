    // create the query type (IQueryable, DbSet, etc...)
    IQueryable<Entity> query = context.Entity;
    
    // check the parameters and add using the Where method
    if (!string.IsNullOrEmpty(userName))
       query = query.Where(x => x.UserName.Constains(userName));
    
    if (!string.IsNullOrEmpty(surName))
       query = query.Where(x => x.SurName.Constains(surName));
    
    if (!string.IsNullOrEmpty(city))
       query = query.Where(x => x.City == city);
    
    // execute the query and get results...
    var result = query.ToList();
