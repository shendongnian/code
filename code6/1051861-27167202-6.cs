    public ActionResult AssignRole(int id = 0)
    {
        var user = (from u in db.users
                   join r in db.UserRoles on r.UserId equals u.id into g
                   where u.id == id
                   select new user
                   {
                       id = u.id,
                       email = u.email,
     // assign the properties like any normal select.
                       Roles = g.Select(x => new Role { RoleName = x.rolename ... })
                   })
                   .FirstOrDefault();
        return View(user); // Update your view to expect a single user
    }
