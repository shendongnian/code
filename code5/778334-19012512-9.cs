    [HttpPost]
    public ActionResult Index(IEnumerable<User> model)
    {
        // Process your data.
        return View(model);
    }
