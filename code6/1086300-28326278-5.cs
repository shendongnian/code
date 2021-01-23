    // map data
    asset.Title = model.Title;
    asset.Description = model.Description;
    //etc.
   
    // You might be tempted to do the following:
    // asset.Categories = db.Categories.Where(m => model.SelectedCategoryIds.Contains(m.Id));
    
    // Instead you must first, remove any categories that the user deselected:
    asset.Categories.Where(m => !model.SelectedCategoryIds.Contains(m.Id))
        .ToList().ForEach(m => asset.Categories.Remove(m));
    // Then you need to add any newly selected categories
    var existingCategories = asset.Categories.Select(m => m.Id).ToList();
    db.Categories.Where(m => model.SelectedCategoryIds.Except(existingCategories).Contains(m.Id))
        .ToList().ForEach(m => asset.Categories.Add(m));
