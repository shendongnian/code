    public class CustomSearchResult : Sitecore.ContentSearch.SearchTypes.SearchResultItem
    {
        [IndexField("START DATE FIELD NAME")]
        public virtual DateTime EndDate {get; set;}
    
        [IndexField("END DATE FIELD NAME")]
        public virtual DateTime StartDate {get; set;}
    } 
