    public class Registration
    {
        [Required, MinLength(2)]
        public string FirstName { get; set; }
        
        [Required, MinLength(2)]
        public string LastName { get; set; }
        
        [DataType(DataType.Password), Required]
        public string Password { get; set; }
        
        [Required, Compare("Password")]
        public string Password2 { get; set; }
        
        [Required, EMailAddress]
        public string Email { get; set; }
        
        [Required, Phone]
        public string Phone { get; set; }
    }
