    ...
    var categories = new List<Category>(this.categoryService.GetCategories())
    // assuming ParentCategoryId == 0 is the root category
    var categoryTree = CategoryTree.Create(categories, o => o.ParentCategoryId == 0);
    var model = new SomeViewModel();
    model.Categories = new SelectList(categoryTree.Flatten(), , "Id", "DisplayText");
    return View(model);
    ...    
    @Html.DropDownListFor(m => m.SelectedCategory, Model.Categories)
    ...
