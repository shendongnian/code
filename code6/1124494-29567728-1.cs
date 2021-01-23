    public class UserViewModel()
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]", ErrorMessage = ErrorMessage_PasswordRegex)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
