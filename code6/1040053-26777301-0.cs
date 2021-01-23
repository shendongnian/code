    // function to return the course catalog list
    public List<CourseCatalog> GetCourseCatalogs()
    {
        var details=db.CourseCatalogs.ToList();
        return details;
    }
    
    // your index action
    public ActionResult Index()
    {
        ViewBag.Catalogs=GetCourseCatalogs();
        return View();
    }
    
    // partial view for your Course details with parameter id to filter the course catalog
    
    public ActionResult CourseDetails(int id)
    {
        var details = db.Courses.Where(t=>t.CatalogId==id).ToList();
        return PartialView(details);
    }
