    public ActionResult AddEatenMeal(int id)
    {
      var meal = mealRepository.GetMeal(id);
      var mealTypes = // get the list of meal types from the database
      EatenMealVM model = new EatenMealVM()
      {
        MealID = meal.Id,
        MealName = meal.Name,
        MealTypeList = new SelectList(mealTypes, "ID", "Name")
      };
      return View(model);
    }
