    var data = db.database_bd.AsQueryable();
     
    if (query.startDate != null)
    {
        data = data.Where(c => c.UploadDate >= query.startDate);
    }
    
    if (!string.IsNullOrEmpty(query.name))
    {
        var list = query.name.split(',');
        data = data.Where(pr => list.Any(pr2 => pr.Name.Contains(pr2)));
    }
