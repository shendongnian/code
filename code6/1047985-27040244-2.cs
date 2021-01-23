    from u in db.Users
    select new { 
                 u.UserName,
                 Permissions = u.Groups
                                .Select(ug => ug.Group)
                                .SelectMany(g => g.Permissions)
                                .Select(gp => gp.Permission
               }
