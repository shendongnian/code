    // begin with true if you start with And operator.
    var predicate = PredicateBuilder.True<TblFamilie>();
    predicate = predicate.And(t => t.CureDate < DateTime.UtcNow.AddDays(-1));
    // you can mix with Or operator too.
    predicate = predicate.Or(t => t.Name.Contains("blah"));
    var results = context.TblFamilie
    .Where(predicate)
    .Select(new
    {
      // your projection here...
    });
    
    // begin with false if you start with Or operator.
    var predicate2 = PredicateBuilder.False<TblFamilie>();
    predicate2 = predicate2.Or(t => t.CureDate < DateTime.UtcNow.AddDays(-1));
    // you can mix with And operator too.
    predicate2 = predicate2.And(t => t.Name.Contains("blah"));
    var results = context.TblFamilie
    .Where(predicate)
    .Select(new
    {
      // your projection here...
    });
    
    // even nesting is possible
    var inner = PredicateBuilder.False<TblFamilie>();
    inner = inner.Or (p => p.Name.Contains("foo"));
    inner = inner.Or (p => p.Name.Contains("bar"));
    
    var outer = PredicateBuilder.True<TblFamilie>();
    outer = outer.And (p => p.CureDate > DateTime.UtcNow.AddDays(-3));
    outer = outer.And (p => p.CureDate < DateTime.UtcNow.AddDays(-1));
    outer = outer.And (inner);
    
    var results = context.TblFamilie
    .Where(outer)
    .Select(new
    {
      // your projection here...
    });
