    [MetadataType(typeof(IUserBase))]
    public class NewUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
