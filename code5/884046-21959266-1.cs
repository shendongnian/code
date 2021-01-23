        public ActionResult Index()
        {
            AdminViewModel model = new AdminViewModel();
            model.UserList = new List<User>();
            model.UserList.Add(new User() { FirstName = "Rami", IsAdmin = true, Id = 10 });
            model.UserList.Add(new User() { FirstName = "James", IsAdmin = false, Id = 20 });
            return View(model);
        }
