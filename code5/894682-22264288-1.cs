    var query = context.GetQueryable<CustomSearchResultItem>();
    var predicate = PredicateBuilder.True<CustomSearchResultItem>();
    predicate = predicate.And(item =>
        item.ContentTitle.Contains(searchfields.searchKeyword));
    // Assumptions made to make the sample compileable.
    predicate = predicate.Or(item => 
        item.ContentShortDescription.Contains(searchfields.searchKeyword));
    System.Diagnostics.Trace.WriteLine(predicate);
    queryResults = query.Where(predicate)
