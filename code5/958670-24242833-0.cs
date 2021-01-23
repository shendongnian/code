    public class Request
    {
        public int id { get; set; }
        
        public string Name { get; set; }
    
        [Required]
        public Gender? Gender { get; set; }
    }
