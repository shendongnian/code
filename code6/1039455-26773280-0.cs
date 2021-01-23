    public class UserRegistrationViewModel
    {
      [Required(ErrorMessage = "Domain ID")]
      [Display(Name = "Domain ID")]
      public string domainid { get; set; }
      [Required(ErrorMessage = "Choose Role")]
      [Display(Name = "Role")]
      public string role { get; set; }
      [Required(ErrorMessage = "Choose Country")]
      [Display(Name = "Country")]
      public string country { get; set; }
      [Required(ErrorMessage = "Choose BU")]
      [Display(Name = "BU")]
      public string bu { get; set; }
      [Required]
      [Display(Name = "Email"),DataType(DataType.EmailAddress)]
      [EmailAddress]
      public string email { get; set; }
      public SelectList RoleList { get; set; }
      public SelectList CountryList { get; set; }
      public SelectList BUList { get; set; }
    }
