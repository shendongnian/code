    public ActionResult Edit(long id = 0)
    {
        ViewBag.ParentCategoryID = NonNullCatagoriesQuery(db);
        ...
    }
    
    public ActionResult Create()
    {
        ViewBag.ParentCategoryID = NonNullCatagoriesQuery(db);
        ...
    }
