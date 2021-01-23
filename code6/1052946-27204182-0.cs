    var query = db.Projects.AsQueryable();
    
    if (!string.IsNullOrWhitespace(projectName))
    {
         query = query.Where(w => w.Name == projectName);
    }
    
    if (date != null)
    {
       query = query.Where(w => w.Date == date);
    }
    
    return query.ToList();
