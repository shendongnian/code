    var query = db.Pages.Where(u => !u.MetaNoSearch && u.PaOk && u.Category.Name == cat);
    
    if (!string.IsNullOrWhiteSpace(sub))
        query = query.Where(u => u.SubCategory.CatName == sub);
    
    query = query.OrderByDescending(u => u.PaCreatedOn);
    
    return PartialView(query.ToList());
