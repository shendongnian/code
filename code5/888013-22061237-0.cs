    public class UserInformation
    {
        [Required]
        public string Name { get; set; }
    
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    
        [Required]
        [Url]
        public string Website { get; set; }
    
        [Required]
        [CreditCard]
        public string CreditCard { get; set; }
    
        [Required]
        [FileExtensions(Extensions = "jpg,jpeg")]
        public string Image { get; set; }
    }
