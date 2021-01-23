        var UserInRole = db.UsersInRoles.Include(u => u.UserProfile).Include(u => u.Roles)
        .Select (m => new 
        {
            UserName = u.UserProfile.UserName,
            RoleName = u.Roles.RoleName
        });
