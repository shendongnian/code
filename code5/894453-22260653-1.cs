    IEnumerable<RestCategories> categories = API.GetCategoryResults("test", "test");
    var categoryModels = categories.OrderBy(c => c.Order)
                                   .Select(c => new CategoryViewModel
                                           {
                                               Category = c,
                                               Items = OneApi.GetItemsForCategory(ConfigurationManager.AppSettings["Key1"], ConfigurationManager.AppSettings["Key2"], cat.ID.ToString())
                                           })
                                   .ToList();
    return View(modelCat);
