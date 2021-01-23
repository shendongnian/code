    public class YourViewModel
    {
        [Required]
        public string CategoryId { get; set; }
    
        public IEnumerable<Category> Categories { get; set; }
    }
