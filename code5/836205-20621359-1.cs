        // GET api/search
        public List<SearchFormula> Get(string searchTerm)
        {
            var searchItems = SearchData(searchTerm);
            return searchItems;
        }
        public static List<SearchFormula> SearchData(string searchString)
        {
            var searchResults = new List<SearchFormula>();
            searchResults.Add(new SearchFormula { Description = "desc1", Title = "title1", Url = "http://url.com" });
            searchResults.Add(new SearchFormula { Description = "desc2", Title = "title2", Url = "http://url.com" });
            return searchResults;
        }
