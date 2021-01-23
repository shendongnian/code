     public ActionResult List(string name, int? page)
     {
     int pageNumber = (page ?? 1);
     var model =
        repository.GetMeals()
        .Where(r => name == null || r.Name.StartsWith(name))
        .Select(r => new Meal
        {
           Id = r.Id,
           Name = r.Name,
           Protein = r.Protein,
           Carbohydrates = r.Carbohydrates,
           Fat = r.Fat,
           Calories = r.Calories
        }).ToPagedList(pageNumber , 50);
        if(Request.IsAjaxRequest())
        {
            return PartialView("_Meals", model);
        }
        return View(model);
}
