    public ActionResult Create()
    {
        var languages = new List<Language>();
        using (MyDBContext db = new MyDBContext())
        {
            languages = db.Languages.ToList();
        }
    
        ViewBag.ID = new SelectList(languages, "ID", "Title");
        return View();
    }
