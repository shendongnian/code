    var searchResult = searchResults[i];
    foreach (var srProperty in searchResultsProperties)
    {
        var collectionType = srProperty.PropertyType;
        if(!collectionType.IsGenericType || collectionType.GetGenericTypeDefinition() != typeof(IEnumerable<>))
        {
            throw new InvalidOperationException("All SearchResults properties should be IEnumerable<Something>");
        }
        var itemType = collectionType.GetGenericArguments()[0];
        var itemProperties = itemType.GetProperties().Where(p => p.Name != "Match");
        var items = ((IEnumerable<IHaveMatchProperty>) srProperty.GetValue(searchResult))
            // Materialize the enumerable, in case it's backed by something that
            // would re-create objects each time it's iterated over.
            .ToList();
        foreach (var item in items)
        {
            var propertyValues = itemProperties.Select(p => (string)p.GetValue(item));
            item.Match = propertyValues.Any(v => searchTerms.Any(v.Contains));
        }
        var orderedItems = items.OrderBy(i => i.Match);
        srProperty.SetValue(srProperty, orderedItems);
    }
