    public HieraricalCategoryList MapCategories(FlatCategoryList flatCategoryList)
    {
        var categories = (from fc in flatCategoryList.Categories
                          select new Category() {
                              ID = fc.ID,
                              Name = fc.Name,
                              ParentID = fc.ParentID
                          }).ToList();
        var lookup = categories.ToLookup(c => c.ParentID);
        foreach(var c in categories)
        {
            if(lookup.Contains(c.ID))
                c.ChildCategories = lookup[c.ID].ToList();
        }
        return new HieraricalCategoryList() { Categories = categories };
    }
