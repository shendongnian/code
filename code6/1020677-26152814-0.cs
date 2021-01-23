    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(FamilyApplicationViewModel model)
    {
        var user = "Sam";
        model.Family.CreatedBy = user;
        model.Family.ModifiedBy = user;
        model.Family.FamilyApp = new FamilyApp();        
        model.Family.FamilyApp.AppYear = DateTime.Now.Year;
        model.Family.FamilyApp.ModifiedBy = user;
        model.Family.FamilyApp.CreatedBy = user;
        
        db.Family.Add(model.Family);
        db.SaveChanges();
    }
