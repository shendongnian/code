    [Required]
    
        [StringLength(100, ErrorMessage = "Must be at least {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
