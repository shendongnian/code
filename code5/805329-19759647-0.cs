          public class LoginProfileModel {
        
            [DisplayName("Login ID")]
            [Required(ErrorMessage = "Login ID is required.")]
            public string LogonID { get; set; }
        
            [DisplayName("Password")]
            [Required(ErrorMessage = "Password cannot be blank.")]
            [StringLength(20, MinimumLength = 3)]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    
        public SomeOtherClassThatNeedsLoginInfo : LoginProfileModel{
    
             public string Property {get;set;}
    }
