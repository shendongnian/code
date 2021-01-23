    var pgs = db.Pages
        .Where(u => u.MetaNoSearch == false &&
               u.PaOk == true &&
               u.Category.Name == cat);
    
    if (!string.IsNullOrWhiteSpace(sub))
    {
        pgs = pgs.Where(u => u.SubCategory.CatName == sub);
    }
    
    return PartialView(pgs.OrderByDescending(u => u.PaCreatedOn).ToList());
