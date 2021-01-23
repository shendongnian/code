    public class MyNiceRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    
        public string SomeOptionalField { get; set; }
    
        public Dictionary<string, string> TheRest { get; set; }
    }
