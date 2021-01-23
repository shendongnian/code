    using(WebStoreEntities1 db1 = new WebStoreEntities1())
    {
        allSubCategory = db1.CategoryToSubCategories
                            .Where(a => a.CategoryId.Equals(id))
                            .OrderBy(a => a.SubCategory.SubCategoryName)
                            .Select(a => new {
                                          SubCategoryId = a.SubCategoryId, 
                                          SubCategoryName = a.SubCategory.SubCategoryName })
                            .ToList();
    }
