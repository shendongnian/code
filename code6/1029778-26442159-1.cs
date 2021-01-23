    [HttpPost]
    public ActionResult Index([ModelBinder(typeof(AModelDataBinder))]AModel input)
    {
        // Handle POST
        return View();
    }
