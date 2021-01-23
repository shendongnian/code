    public ActionResult AssignRole(int id = 0)
    {
        var user = (from u in db.users
                   join r in db.Roles on r.UserId equals u.id into g
                   where u.id == id
                   select new user
                   {
                       id = u.id,
                       email = u.email,
                       Roles = g.Select(x => new Role { ... }) // assign the properties
                   })
                   .FirstOrDefault();
        return View(user); // Update your view to expect a single user
    }
