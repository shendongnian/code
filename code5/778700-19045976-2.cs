    var predicate = PredicateBuilder.False<Parameter>();
    foreach (var param in Parameters)
    {
        predicate = predicate.Or(p => p.Name == param.Name && p.Value == param.Value);
    }
    // building (u => u.ParametersList.Any(predicate))
    var u = Expression.Parameter(typeof(User), "u");
    var parametersproperty = Expression.Property(u, "ParametersList");
    var anyCall = Expression.Call(parametersproperty, typeof(Queryable).Getmethod("Any"), predicate);
    
    var lambda = Expression.Lambda<User, bool>(u, anyCall);
    
    linq = linq.Where(lambda);
