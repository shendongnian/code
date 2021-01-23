    var lookup = list.Categories
        .Select(category => new Category()
        {
            ID = category.ID,
            Name = category.Name,
            ParentID = category.ParentID,
        })
        .ToLookup(category => category.ParentID);
    foreach (var category in lookup.SelectMany(x => x))
        category.ChildCategories = lookup[category.ID].ToList();
    var newList = new HieraricalCategoryList()
    {
        Categories = lookup[null].ToList(),
    };
