    public ActionResult Create()
    {
      RecipeVM model = new RecipeVM();
      // add 5 'null' ingredients for binding
      model.SelectedIngredients = new List<int?>() { null, null, null, null, null };
      ConfigureViewModel(model);
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(RecipeVM model)
    {
      if (!ModelState.IsValid)
      {
        ConfigureViewModel(model);
        return View(model);
      }
      // Initialize new instance of your data model
      // Map properties from view model to data model
      // Add values for user, create date etc
      // Save and redirect
    }
    private void ConfigureViewModel(RecipeVM model)
    {
      model.IngredientList = new SelectList(db.Ingredients, "IngredientId", "IngredientName");
    }
