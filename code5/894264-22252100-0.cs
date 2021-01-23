    [HttpGet]
    public ActionResult Categories()
    {            
        MyModel modelApi = new MyModel();
        IEnumerable<RestCategories> itemsResult = modelApi.GetCategoryResults("test", "test");
        CategoriesViewModel modelCat = new CategoriesViewModel
        {
            //I need some magic here to return ienumerable dataset of RestCategories
            Categories = itemsResult.                                   
        };
        return View(modelCat);
    }
