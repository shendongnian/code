    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
