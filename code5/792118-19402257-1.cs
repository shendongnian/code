    [Required]
    [Display(ResourceType = typeof (WebResources), Name = WebResources.LabelAddress)]
    [Required(ErrorMessage = "Please enter Numeric Only")]
    [RegularExpression(@"^\d+$", ErrorMessage = “Enter Numeric only”)]
    
    public int SerialAddress { get; set; }
