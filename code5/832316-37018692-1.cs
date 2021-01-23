    [Required]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "Password Lenght should be between 4 and 20.")]
    [CustomCompare("Password", "My own message: Passwords do not match!")] // <-- Use your new Custom Attribute here
    [Display(Name = "Retype Password")]
    public string RePassword { get; set; }
