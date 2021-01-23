    public class LoginModel
    {
        [Required]
        [Display(Name = "Username:")]
        public String UserName { get; set; }
        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
