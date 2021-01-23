    IQueryable<User> query = cnt.Users;
    if(userName != null)
        query = query.Where(x => x.name == userName)
    if(roles.Any())
        query = query.Where(x => roles.Contains(x.role_id));
    if(applications.Any())
        query = query.Where(x => applications.Contains(x.application_id))
    
    var result = query.Count();
