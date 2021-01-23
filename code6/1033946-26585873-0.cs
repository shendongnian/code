    // Called when updates takes place...
    private void OnCategoryListUpdated()
    {
        foreach (var updatedCategory in UpdatedCategoryList)
        {
            OnCategoryUpdated(updatedCategory);
        }
    }
    
    private void OnCategoryUpdated(Category updatedCategory)
    {
        var oldCategoryInList = CategoryList.SingleOrDefault(c => c.Id == updatedCategory.Id);
        if (oldCategoryInList != null)
        {
            oldCategoryInList.PropertyA = updatedCategory.PropertyA;
            // Etc...
        }
    }
