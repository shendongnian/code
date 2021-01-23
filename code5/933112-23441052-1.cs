    public IEnumerable<Tuple<Item,decimal, decimal>> GetCurrentItems(string filter = "", int categoryId = 1) {
        dynamic result;
        var categoryServices = new CategoryServices();
        IEnumerable<int> categoryIdAndChildCategoriesId = categoryServices.GetCategoryIdAndChildsId(categoryId);
        if (!string.IsNullOrWhiteSpace(filter))
        {
            result = this.GetAllCurrentItems(x => ((string)(x.Item.Name)) == filter);
        }
        else if(categoryId != 1)
        {
            result = this.GetAllCurrentItems(x => x.Item.ItemCategories.Any(x => categoryIdAndChildCategoriesId.Contains(x.CategoryId)));
        }
        return result;
    }
