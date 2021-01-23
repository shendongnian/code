    public ActionResult Index()
    {
            var users = Context.Users.Where(x=>x.Roles.Any(y=>y.RoleName.Equals("Coordinator"))).ToList();
            return View(users);
    }
