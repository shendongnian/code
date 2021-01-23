    var pgs = db.Pages.Where(u => u.MetaNoSearch == false)
                        .Where(u => u.PaOk == true)
                        .Where(u => u.Category.Name == cat);
    
    if (!string.IsNullOrWhiteSpace(sub))
    {
        pgs = pgs.Where(u => u.SubCategory.CatName == sub);   
    }
    
    var result = pgs.OrderByDescending(u => u.PaCreatedOn).ToList();
