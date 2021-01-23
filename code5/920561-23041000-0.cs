    public class PagedCountryList
    {
        private IEnumerable<Country> countries { get; set; }
        public int totalResult { get; set; }
        public int elementsPerPage { get; set; }
        public int pageNumber { get; set; }
    
        public PagedCountryList(IEnumerable<Country> countries, int totalResult, int elementsPerPage, int pageNumber)
        {
           //you cant write something like this (because it is ambiguous)
           //countries = countries;
            this.countries = countries;
            this.totalResult = totalResult;
            this.elementsPerPage = elementsPerPage;
            this.pageNumber = pageNumber;
        }
    }
