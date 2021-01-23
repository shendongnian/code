    public ActionResult Index()
        {
            var model = db.Items.ToList(); ////Your model that you want to pass
            return View(model);
        }
