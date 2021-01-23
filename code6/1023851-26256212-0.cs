    public ActionResult Index()
        {
            var model = db.Items; ////Your model that you want to pass
            return View(model);
        }
