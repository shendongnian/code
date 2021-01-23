    private static AdminObjectModel create = new RecipeObjectModel();
    [HttpPost, ValidateInput(false)]
    public void CreateJSON(AdminObjectModel jsonData)
    {
        create = jsonData;
    }
    
    [HttpPost, ValidateInput(false)]
    public ActionResult Create(IEnumerable<HttpPostedFileBase> images, IEnumerable<HttpPostedFileBase> small_images)
    {
        string t = create.Details.Name;
        ...
        return Redirect("/admin/create");
    }
