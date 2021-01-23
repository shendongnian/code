    public ActionResult Create()
    {
        ViewModel vmodel = new ViewModel();
        vmodel.Projects = GetProjects(); 
        return View(vmodel);
    }
    private List<SelectListItem> GetProjects()
    {
         return db.GetProjects(User.Identity.Name)
                     .Select(x => new SelectListItem { Text = x.Description,
                                                       Value = x.Id }).ToList();   
    }
