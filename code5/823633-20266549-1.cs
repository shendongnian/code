    public ActionResult Index()
    {
    
        ViewBag.Gender = new SelectList(DDLHelper.GetGender(), "Value", "Text");
        return View();
    }
