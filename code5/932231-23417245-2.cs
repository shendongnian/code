    [HttpPost, ValidateInput(false)]
    public AdminObjectModel CreateJSON(AdminObjectModel jsonData)
    {
        AdminObjectModel r = jsonData;
    
        return r;
    }
    
    [HttpPost, ValidateInput(false)]
    public ActionResult Create(IEnumerable<HttpPostedFileBase> images, IEnumerable<HttpPostedFileBase> small_images)
    {
        ...
        return Redirect("/admin/create");
    }
