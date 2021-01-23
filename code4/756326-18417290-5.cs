    [Display(Name = "New Password")]
    public string New { get; set; }
    
    
    [Display(Name = "Confirm Password")]
    [CompareWithDisplayName("New")]
    public string ConfirmPassword { get; set; }
