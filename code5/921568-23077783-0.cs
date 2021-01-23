    public ActionResult Details(int id = 0)
        {
            UsersInRoles usersinroles = db.UsersInRoles.Include(u => u.UserProfile).Include(r => r.Role).Where(i => i.UsersInRolesID == id).SingleOrDefault();
            if (usersinroles == null)
            {
                return HttpNotFound();
            }
            return View(usersinroles);
        }
