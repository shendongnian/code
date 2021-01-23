    private void DeleteChildCategories(Category category) 
    {
        foreach (Category subCategory in category.ChildCategories.ToList())
            {
                if (subCategory.SubCategories.Count() > 0)
                {
                    DeleteChildCategories(subCategory);
                }
                else
                {
                    _db.Category.Remove(subCategory);
                }
            }
        _db.Category.Remove(category);
    }
