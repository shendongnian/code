        public class YourOriginalClassName
        {
            public int PacientID { get; set; }
            
            [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
            public string PacientUsername { get; set; }
        
            [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
            public string PacientPassword { get; set; }
    
            [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Please provide valid email")]
            public string PacientEmail { get; set; }
            
            [Compare("PacientPassword", ErrorMessage = "Confirm password dose not match.")]
            [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
            public string ConfirmPassword { get; set; }
        }
