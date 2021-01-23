    public class ListViewModel
    {
        [Required(ErrorMessage = " A Name is required *")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(160, MinimumLength = 2, ErrorMessage = "Must be between 2 & 160 characters in length.")]
        public string AuthorName { get; set; }
    
        [Required(ErrorMessage = "Email address required *")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(160, MinimumLength = 2, ErrorMessage = "Must be between 2 & 160 characters in length *")]
        [EmailValidation(ErrorMessage = "Must be valid email *")]
        public string AuthorEmail { get; set; }
    
        [Required(ErrorMessage = " A Message is required *")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(4000, MinimumLength = 2, ErrorMessage = "Must be between 2 & 4000 characters in length *")]
        public string Body { get; set; }
    
        
        public IList<Entry> Posts { get; private set; }
        public IList<Comment> Comment { get; private set; }
    }
