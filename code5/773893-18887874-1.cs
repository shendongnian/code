    public class SearchResultSet
    {
        public IList<SearchResult> Results { get; set; }
        public long Total { get; set; }
    } 
    public class SearchController : Controller
    {  
        public ActionResult Index(string q = "")
        {
            return View(GetModel(q));
        }
        
        private SearchResultSet GetModel(string searchQuery)
        {
            // Get search results
        }
    }
