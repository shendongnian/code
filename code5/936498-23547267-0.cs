        public ActionResult Index()
        {
            MyModel model = new MyModel();
            model.Types = new List<string>();
            model.Types.Add("Admin");
            model.Types.Add("User");
            model.Types.Add("SuperAdmin");
            return View(model);
        }
