    public class AuthenticateRequest {
        
        [Required(AllowEmptyStrings=False, ErrorMessage="E-mail Address Required")]
        public String Email {get; set;}
        [Required(AllowEmptyStrings=False, ErrorMessage="Password is required")]
        public String Password {get; set;}
        public int NumAttempts {get; set;}
    } // end class AuthenticationRequest
