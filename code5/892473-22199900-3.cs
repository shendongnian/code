    [HttpPost]
    public ActionResult Create(CreateCarVM model)
    {
      if(ModelState.IsValid)
      {
        //check for model.SelectedCategory now
       // to do :Save and Redirect (PRG pattern)
      }
      model.Categories=GetCategories();
      return View(model);
    }
