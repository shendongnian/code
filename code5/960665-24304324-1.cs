    public class RegisterViewModel
    {
        [Required(ErrorMessage="This field is required")]
        [Display(Name = "User name", Prompt="Please enter user name...")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", Prompt="Please enter password...")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password", Prompt = "Please enter confirm password...")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Role")]
        public Roles Role { get; set; }
    }
