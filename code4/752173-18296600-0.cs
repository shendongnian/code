    [HttpPost]
    [ValidateInput(false)]
    public ActionResult Index(string search)
    {
        ViewBag.Message = search;
        return View();
    }
