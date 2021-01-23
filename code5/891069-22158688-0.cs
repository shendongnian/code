    public class NewsItemViewModel
    {
        [Required(ErrorMessage = "Title is Required")] 
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Body is Required")] 
        public DateTime DateCreate { get; set; }
        
        public string Category { get; set; }
        public IEnumerable<SelectListItem> CategoryChoices { get; set; }
    }
