    public class PageElement
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    
        public string Data { get; set; }
    }
    
    public class PageElementAnswer : PageElement 
    {
    }
    
    public class PageElementAlternative : PageElement 
    {
    }
    
    public class Page
    {
        public int Id { get; set; }
        public virtual ICollection<PageElementAlternative> Alternatives { get; set; }
        public virtual ICollection<PageElementAnswer> Answers { get; set; }
    }
