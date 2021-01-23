    public IEnumerable<Item> GetItems()
    {
        var index = ContentSearchManager.GetIndex("sitecore_master_index");
        using (var context = index.CreateSearchContext())
        {
            IQueryable<SearchResultItem> query = context.GetQueryable<SearchResultItem>().Where (item  => item.Name == "Home");
            SearchResults<SearchResultItem> results = query.GetResults();
            return results.Hits.Select(hit => hit.Document.GetItem());
        }
    }
