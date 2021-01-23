    public ActionResult Index()
    {
        var typelist = db.TypesQuestions.Select(x => new SelectListItem 
        {
             Text = x.Name,
             Value = x.Id.ToString()
    	}).ToList();
        ViewData["Types"] = typelist;
        return View();
    }
