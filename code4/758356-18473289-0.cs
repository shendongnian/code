    [Required]
    [Display(Name = "New Password")]
    public string New { get; set; }
    [System.Web.Mvc.Compare("New")]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }
