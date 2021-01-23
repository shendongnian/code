    public ActionResult Index(string RoleName, string UserName)
    {
        SelectList list = new SelectList(Roles.GetAllRoles());
        ViewBag.Roles = list;
        return View();
    }
