    public ActionResult Create(UserGoalsStepViewModel model)
    {
        // what are we updating? assume it's a project
        var p = from db.Projects.Where(x => x.Id == model.id;
    
        p.SomeProperty = model.SomeProperty;
        db.SaveChanges();
    }
