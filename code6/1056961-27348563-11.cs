    [HttpPost]
    public ActionResult AddEatenMeal(EatenMealVM model)
    {
      if (!ModelState.IsValid)
      {
        var mealTypes = // get the list of meal types from the database
        model.MealTypeList = new SelectList(mealTypes, "ID", "Name");
        return View(model);
      }
      // Initialize new EatenMeal class
      // Map properties from view model (including setting user name) 
      // Save and redirect
    }
