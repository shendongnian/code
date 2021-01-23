    public class SearchResult : IEquatable<SearchResult>
    {
        public string Url{get;set;}
        public string SearchText { get; set; }
        public bool Equals(SearchResult other)
        {
            if (other == null)
                return false;
            return string.Concat(this.Url, this.SearchText).Equals(string.Concat(other.Url, other.SearchText), StringComparison.OrdinalIgnoreCase);
        }
    }
