    var predicate = PredicateBuilder.False<Company>();
    
    foreach (var keyword in searchArray)
    {
        predicate = predicate.Or(c => c.Name.Contains(keyword));
    }
    
    var query = Companies.Where(predicate.Expand());
