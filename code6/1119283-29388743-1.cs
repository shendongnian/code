    public class EventViewModel
    {
        [Required]
        public string Name { get; set; }
    
        [Required]
        public DateTime Start { get; set; }
    
        [Required]
        [GreaterThan("Start")]
        public DateTime End { get; set; }
    }
