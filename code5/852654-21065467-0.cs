    enum SearchStrategy
    {
        Contains,
        StartsWith,
        EndsWith,
        Equals
    }
    class SearchItem
    {
        public SearchStrategy SearchStrategy { get; set; }
        public string Value { get; set; }
    }
