    public class LoginPage
    {
        [Required(ErrorMessage = "Enter login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Enter password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
