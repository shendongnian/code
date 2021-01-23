      public ActionResult Index()
      {
            var roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            var users = roleManager.FindByName("Coordinator").Users;
    
            return View(users);
      }
