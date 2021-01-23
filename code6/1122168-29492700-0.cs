    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
    
        [Required]
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
    }
