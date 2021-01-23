    public class Login {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    
    public class Register : Login {
        public string ConfirmPassword { get; set; }
    }
