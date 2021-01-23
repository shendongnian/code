    public ActionResult Index()
    {
        using (YourContext db = new YourContext())
        {
            var model = new SomeViewModel();
            model.Tags = string.Join(" ", db.Tags.Select(t => t.Description).ToList());
            return View(model);
        }
    }
