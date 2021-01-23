    public class CustomerViewModel
    {
        [Required]
        public int CustomerId { get; set; }
        
        [Required]
        public int RetailerId { get; set; }
        [Required]
        public string  CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
    }
