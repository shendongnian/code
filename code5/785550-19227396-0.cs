    public class UserLoginViewModel
    {
      [HiddenInput(DisplayValue = false)]
      public long UserID { get; set; }
      
      [Required(ErrorMessage = "Please enter a password")]
      [DataType(DataType.Password)]
      [Compare("Password")]
      [Display(Name = "Your Password")]
      public string Password { get; set; }
      [DataType(DataType.Password)]
      [Compare("Password", ErrorMessage="Passwords do not match")]
      [System.ComponentModel.DataAnnotations.Schema.NotMapped]
      [Display(Name = "Confirm Password")]
      public string ConfirmPassword { get; set; }
    }
