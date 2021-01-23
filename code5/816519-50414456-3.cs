    var searchCriteria = new List<Expression<Func<Name, bool>>();
    
      if (!string.IsNullOrWhiteSpace(first))
          searchCriteria.Add(q => q.first.Contains(first));
      if (!string.IsNullOrWhiteSpace(last))
          searchCriteria.Add(q => q.last.Contains(last));
      //.. around 50 additional criteria
    var query = Db.Names.AsQueryable();
    if(searchCriteria.Any())
    {
        var joinedSearchCriteria = Join(Expression.Or, searchCriteria);
        query = query.Where(joinedSearchCriteria);
    }
      return query.ToList();
