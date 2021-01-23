    public ActionResult Index(DateTime? SearchDate)
    {
        var query = ...;
    
        if (SearchDate != null)
        {
             query = ...;
        }
    
        return View(query);
    }
