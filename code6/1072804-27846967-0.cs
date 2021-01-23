    ...
    
    [HttpPost]
    public ActionResult Index(string text)
    {
        TempData["Text"] = text;
        return RedirectToAction("About", "Home");
    }
    
    public ActionResult About()
    {
        ViewBag.Message = TempData["Text"];
        return View();
    }
