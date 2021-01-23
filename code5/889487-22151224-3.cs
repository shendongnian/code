    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        [MyRemote(typeof(RegisterViewModel),"UserName")]
        public string UserName { get; set; }
    
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [MyRemote(typeof(RegisterViewModel),"MyOtherProperty")]
        public string MyOtherProperty { get; set; }
    }
