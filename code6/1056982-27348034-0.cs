    using (var context = new DbContext())
    {
        var rolesForUser = await context.UserRoles.Where(u => u.UserId == userId)
                                    .Join(
                                         context.Roles,
                                         u => u.RoleId,
                                         r => r.Id,
                                         (userRole, role) => role).ToListAsync();
    
       // rolesForUser now has a list role classes.
    }
