        public class UserMetaData
        {
          [Key]
          public int UserId { get; set; }
    
          [Required]
          [StringLength(15, MinimumLength = 3)]
          [Display(Name = "Username*: ")]
          public string Username { get; set; }
      
          [Required]
          [EmailAddress]
          [StringLength(25)]
          [Display(Name = "Email Address*: ")]
          public string Email { get; set; }
    
          [Required]
          [DataType(DataType.Password)]
          [StringLength(50, MinimumLength = 4)]
          [Display(Name = "Password*: ")]
          public string Password { get; set; }
      
          [DataType(DataType.Password)]
          [Display(Name = "Confirm Password*: ")]
          [CompareObsolete("Password", ErrorMessage = "The password and confirmation password do not match.")]
          public string ConfirmPassword { get; set; }
    
          [Required]
          [Display(Name = "Your Grade*: ")]
          public string Grade { get; set; }
        }
