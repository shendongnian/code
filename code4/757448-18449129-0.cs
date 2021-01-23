    public class UserLoginModel 
    { 
        [Required(ErrorMessage = "Please enter your username")] 
        [Display(Name = "User Name")]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [MaxLength(50)]
        public string Password { get; set; } 
    } 
