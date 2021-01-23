    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
    
        [Required]
        [NotMapped]
        [StringLength(20, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string PlainTextPassword { get; set; }
    
        [Required]
        [StringLength(300)]//This is optional
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
