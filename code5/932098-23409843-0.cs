    internal void PopulateCentreChoices(TravelInfoVM model)
    {
        model.Centres = db.Centres.Select(c=> new SelectListItem {Text = c.Name, Value = c.Code}).ToList();
    }
    ...
    public ActionResult Create(){
      var model = new TravelInfoVM();
      PopulateCentreChoices(model);
      return View(model);
    }
    
    [HttpPost]
    public ActionResult Create(TravelInfoVM model){
      if(ModelState.IsValid){
        //save
        //redirect
      }
      PopulateCentreChoices(model);
      return View(model);
    }
    
