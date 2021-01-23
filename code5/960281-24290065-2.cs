    var myQueryable = db.Countries.AsQueryable();
    
    if (!string.IsNullOrWhiteSpace(searchAlpha2))
    {
        myQueryable = myQueryable.Where(c => c.Alpha2.Contains(searchAlpha2));
    }
    ...
    
    var countries = myQueryable.ToList();
