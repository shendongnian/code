    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
    public class QuestionsListViewModel
    {
        public IEnumerable<Question> Questions { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
