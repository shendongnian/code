    @helper PrintCategories(dynamic categories)
    {
        foreach (var item in categories)
        {
            @item.CategoryName
            <br />
            var subCategories = item.SubCategories;
            if (subCategories != null && subCategories.Count > 0)
            {
                PrintCategories(subCategories);
            }
        }
    }
    
    
    @PrintCategories(Model.categories)
