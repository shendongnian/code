    [HttpGet]
    public ActionResult GetPageHeader()
    {
       return PartialView(@"~/Views/Shared/_PageHeader.cshtml");
    }
    [HttpGet]
    public ActionResult GetPageCategories()
    {
       var categories = databaseContext.GetAllCategories(); //Get your categs
       return PartialView(@"~/Views/Shared/_Categories.cshtml",categories);
    }
