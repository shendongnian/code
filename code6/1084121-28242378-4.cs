    ISearchIndex index = ContentSearchManager.GetIndex("sitecore_web_index");
    using (var context = index.CreateSearchContext())
    {
        var results = context.GetQueryable<DateSearchResultItem>()
            .Where(item => item.TemplateId == new ID(templateId));
    
        if (String.IsNullOrEmpty(endDateItemFieldName))
        {
            results = results
                .Where(item => item.StartDate >= startDateTime)
                .Where(item => item.StartDate <= endDateTime);
        }
        else
        {
            results = results
                .Where(item => item.EndDate >= startDateTime)
                .Where(item => item.EndDate <= endDateTime);
        }
    
        var compiledQuery = results.GetResults();
        int totalMatches =  compiledQuery.TotalSearchResults;
    
        foreach (var hit in compiledQuery.Hits)
        {
            Item item = hit.Document.GetItem();
        }
    }
