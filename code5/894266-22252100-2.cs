    [HttpGet]
    public ActionResult Categories()
    {            
        MyModel modelApi = new MyModel();
        IEnumerable<RestCategories> itemsResult = modelApi.GetCategoryResults("test", "test");
        CategoriesViewModel modelCat = new CategoriesViewModel
        {
            Categories = itemsResult                                  
        };
        return View(modelCat);
    }
