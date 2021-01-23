        public class AccountEmail { }
        public class AccountCredentials : AccountEmail
        {
            public Password Password { get; set; }
        }
        
        public class PasswordReset : AccountCredentials
        {
            [Microsoft.Build.Framework.Required]
            public string ResetToken { get; set; }
            public Password NewPassword { get; set; }
        }
        public class Password
        {
            [Required(ErrorMessage = "xxx.")]
            [StringLength(30, MinimumLength = 6, ErrorMessage = "xxx")]
            public string Value { get; set; }
        }
