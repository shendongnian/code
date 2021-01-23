    public ActionResult Create()
    {
      RecipeViewModel model = new RecipeViewModel();
      // Populate the collection of available ingredients
      model.IngredientList = new SelectList(db.Ingredients, "ID", "Name");
      // if you want to pre select some options, then: model.SelectedIngredients = new int[] { 1, 4, 7 };
      return View(model);
    }
    [HttpPost]
    public ActionResult Create(RecipeViewModel model)
    {
      // model.SelectedIngredients will contain the ID's of the selected ingredients
    }
