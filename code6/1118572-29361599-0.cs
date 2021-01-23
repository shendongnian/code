    public ActionResult ChangeLanguage(ViewModels.HomeViewModel model,int id)
    {
    this.HVM.SelectedLanguage = 
    this.HVM.AvailableLanguages.Where(o => 
    o.ID.Equals(id)).First();
    return RedirectToAction("Index",model);
    }
    public ActionResult Index(ViewModels.HomeViewModel model)
     {
    if(model == null)
    {
        this.HVM = new ViewModels.HomeViewModel();
        
    }
    return View(this.HVM);
    }
