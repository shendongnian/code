    var subcat = new SubCategory();
    var item = new Item();
    subcat.Items.Add(item); // subcat.Items must have been initialized! 
    context.SubCategories.Add(subcat); // Also marks item as Added
    context.SaveChanges();
