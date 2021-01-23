    Expression<Func<CustomSearchResultItem, bool> predicate = item =>
        item.ContentTitle.Contains("lorem") ||
        item.ContentShortDescription.Contains("lorem");
    System.Diagnostics.Trace.WriteLine(predicate);
    var query = context.GetQueryable<CustomSearchResultItem>()
                        .Where(predicate)
