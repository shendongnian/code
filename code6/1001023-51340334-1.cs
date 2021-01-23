    public HieraricalCategoryList MapCategories(FlatCategoryList flatCategoryList)
    {
        var categories = (from fc in flatCategoryList.Categories
                          select new Category() {
                              ID = fc.ID,
                              Name = fc.Name,
                              ParentID = fc.ParentID
                          }).ToList();
        var lookup = categories.ToLookup(c => c.ParentID);
        foreach(var c in rootCategories)//only loop through root categories
        {
            // you can skip the check if you want an empty list instead of null
            // when there is no children
            if(lookup.Contains(c.ID))
                c.ChildCategories = lookup[c.ID].ToList();
        }
        //if you want to return only root categories not all the flat list
        //with mapped child 
        
        categories.RemoveAll(c => c.ParentId != 0);//put what ever your parent id is
        return new HieraricalCategoryList() { Categories = categories };
    }
