    public class SearchResponse {
        public List<SearchResults> Results { get; set; }
        public SearchQuery { get; set; }
    }
    
    public class SearchQuery{
       public string Subject { get; set; }
       public string Location { get; set; }
    }
