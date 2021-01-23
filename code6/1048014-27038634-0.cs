    var predicate = PredicateBuilder.True<Product>();
    
    if(minSpecifed) { predicate = predicate.And (p => p.Price > 100); }
    if(maxSpecified) { predicate = predicate.And (p => p.Price < 1000); }
    predicate= predicate.Or(p.Description.Contains ("foo"));
    ...
    return predicate;  
