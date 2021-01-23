    public ActionResult Index()
    {
        var model = _db.UserProfiles.ToList()
                                    .Select(u => new UserViewModel{
                                         UserName = u.UserName,
                                         UserRoles = Roles.GetRolesForUser(u.UserName)
                                                          .AsEnumerable()
                                    })
                                    .ToList();
        ViewBag.Roles = new SelectList(Roles.GetAllRoles());
        return View(model);
    }
