        [HttpGet]
        public ActionResult AdminView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminView(FormCollection collection)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            if (roleManager.RoleExists(collection["RoleName"]) == false)
            {
                Guid guid = Guid.NewGuid();
                roleManager.Create(new IdentityRole() { Id = guid.ToString(), Name = collection["RoleName"] });
            }
            return View();
        }
