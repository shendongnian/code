    public ActionResult Create()
    {
        ViewBag.Roles = new SelectList(db.Roles, "RoleId", "RoleName");
        return View();
    }
