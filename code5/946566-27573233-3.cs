    var a = 
        from u in session.Query<User>()
        join r in session.Query<Role>() on u.role equals r.id
        where r.id == x.id  // pretend list wants to limit to only certain roles.
        select new { u.Username, Role = r.name, RoleID = r.id }; // Adding the Role ID into this output.
    
    if (list != null) // assume if the list given is null, that means no filter.
    {
        a = a.Where(x => list.Contains(x.RoleID));
        
        // WARNING. Unfortunately using the "theta" format here will not work. Not sure why.
    }
    
    var b = a.ToList(); // actually execute it.
    var c = a.Select(x => new { x.Username, x.Role }).ToList() // if you insist on removing that extra RoleID in the output.
