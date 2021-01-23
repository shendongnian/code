    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.Linq;
    using Sitecore.ContentSearch.SearchTypes;
    using Sitecore.ContentSearch.Linq.Utilities
    using (var context = ContentSearchManager.GetIndex("sitecore_web_index").CreateSearchContext())
                {
                    var results = context.GetQueryable<CustomSearchResult>().Where(i => i.TemplateId == Sitecore.Data.ID.Parse("TEMPLATE GUID") && i.StartDate > StartDateObject && i.EndDate < EndDateObject).GetResults();
                    return results;
                }
