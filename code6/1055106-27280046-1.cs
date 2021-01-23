    public ActionResult Index()
    {
            // Assuming that Coordinator has RoleId of 3
            var users = Context.Users.Where(x=>x.Roles.Any(y=>y.RoleId == 3)).ToList();
            return View(users);
    }
