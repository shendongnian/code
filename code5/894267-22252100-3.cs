    [HttpGet]
    public ActionResult Categories()
    {            
        var modelApi = new MyModel();
        var itemsResult = modelApi.GetCategoryResults("test", "test");
        var modelCat = new CategoriesViewModel
        {
            Categories = itemsResult                                
        };
        return View(modelCat);
    }
