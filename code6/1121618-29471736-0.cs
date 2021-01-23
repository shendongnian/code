    public class LoginModel
    {
        [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string PacientUsername { get; set; }
    
        [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be 8 char long.")]
        public string PacientPassword { get; set; }
    }
