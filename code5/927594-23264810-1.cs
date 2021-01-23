    var data = db.database_bd.AsQueryable();
    
    if (query.startDate != null)
        data = data.Where(c => c.UploadDate >= query.startDate);
    
    if (!string.IsNullOrEmpty(query.name))
    {
        var ids = query.name.Split(',');
        data = data.Where(c => c.Name != null && ids.Contains(c.Name));
    
    if (!data.Any()) //line causing error
    {
         var message = string.Format("No data was found");
         return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
    }
