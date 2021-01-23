    var data = db.database_bd.AsQueryable();
    
    var mainPredicate = PredicateBuilder.True<database_bd>();
    
    if (query.startDate != null)
        mainPredicate = mainPredicate.And(c => c.UploadDate >= query.startDate);
    
    if (!string.IsNullOrEmpty(query.name))
    {
        var namePredicate = PredicateBuilder.False<database_bd>();
        var ids = query.name.Split(',');
        foreach (var id in ids) {
           namePredicate = namePredicate.Or(c => c.Name != null && c.Name.Contains(id));
        }
        mainPredicate = mainPredicate.And(namePredicate);
    }
    data = data.Where(mainPredicate );
    
    if (!data.Any()) //line hopefully causing no more error
    {
         var message = string.Format("No data was found");
         return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
    }
