    public class LoginModel
    {
    
        [Required(ErrorMessage = "Please enter your user name")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
    
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre:")]
        public string Password { get; set; }
    
        [Display(Name = "Beni Hatırla?")]
        public bool RememberMe { get; set; }
    }
