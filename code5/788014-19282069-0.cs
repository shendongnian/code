    [Required(ErrorMessage = "First name is required")]
    [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
    public string F_Name { get; set; }
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(30, ErrorMessage = "Name can be no larger than 30 characters")]
    public string L_Name { get; set; }
