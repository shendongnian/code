    using (CoreSiteContext db = new CoreSiteContext())
    {
        var items = db.Sections
                      .Select(s => new { s.ID, s.Title })
                      .ToList();
    
        var selectList = new SelectList(items, "ID", "Title");
        ViewBag.Sections = selectList;
    }
