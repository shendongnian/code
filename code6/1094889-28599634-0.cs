    public class JobsListViewModel
    {
        public JobsListViewModel()
        {
            searchTerms = new SearchTerms();
        }
        public IEnumerable<JobPost> JobPosts { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public SearchTerms searchTerms { get; set; }
    }
