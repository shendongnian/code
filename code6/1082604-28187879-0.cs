    public class Book{
        
        [Required]
        public string Name{ get; set; }
    
        public List<Page> Pages { get; set; }
    }
    
    public class Page{
        
        [Required]
        public int PageNumber{ get; set; }
    
        [Required]
        public string Content { get; set; }
    }
