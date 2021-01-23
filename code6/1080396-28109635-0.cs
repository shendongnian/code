    public class NewsItemViewModel
    {
        [Required]
        public string NewsTitle { get; set; }
        public string NewsAuthor { get; set; }
        public string NewsSummary { get; set; }
        public string NewsDescription { get; set; }
        public bool NewsAllowComments { get; set; }
        [Required]
        public string NewsContent { get; set; }
        public string NewsSourceName { get; set; }
    }
