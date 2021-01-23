    public static IQueryable<User> GetUsersInRole(DbContext db, string roleName)
    {
      if (db != null && roleName != null)
      {
        var roles = db.Roles.Where(r => r.Name == roleName);
        if (roles.Any())
        {
          var roleId = roles.First().Id;
          return from user in db.Users
                 where user.Roles.Any(r => r.RoleId == roleId)
                 select user;
        }
      }
      return null;
    }
