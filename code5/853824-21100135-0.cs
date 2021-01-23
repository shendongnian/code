    public class FirstNameViewModel 
     {
        [Required]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string Value { get; set; }
    }
     public class FirstNameViewModel 
     {
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(32, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Value { get; set; }
     }
