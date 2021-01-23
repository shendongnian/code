     public class AnnonymousModel
        {
            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
            [Display(Name = "User name")]
            [RegularExpression(@"^[A-Za-z\n\r\0-9_ ]+$")]
            public String RegisterUsername {get; set;}
       }
