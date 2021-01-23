    [DisplayName("Password")]
    [Required(ErrorMessage = "Password is required")]
    [StringLength(3, ErrorMessage = "Password length should be less than 3")]
    public string Password { get; set; }
    [DisplayName("Confirm Password")]
    [Compare("Password", ErrorMessage = "Your passwords must match")]
    [Required(ErrorMessage = "Confirm Password is required")]
    [StringLength(3, ErrorMessage = "Confirm Password length should be less than 3")]       
    public string ConfirmPassword { get; set; }
