    public ActionResult AssignRole(int id = 0)
    {
        // Forgive the use of extension methods here, im more familiar with these
        var user = db.users
                     .Where(w => w.UserID == id)
                     .Join(
                         db.UserRoles,
                         a => a.id,
                         b => b.userID,
                         (u, r) => new { User = u, Roles = r })
                     .Select(
    // You can assign straight to the model, no need for a separate foreach
                         s => new user()
                              {
                                  id = s.User.id,
                                  email = s.User.email,
                                  Roles = s.Roles
                                              .Select(
                                                   r => // assign role properties here
                                                      new Role() { ... })
                                              .ToList()
                              }
                     .ToList();
        return View(user); // Update your view to expect a single user
    }
