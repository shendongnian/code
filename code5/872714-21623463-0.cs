    [Required(ErrorMessage = "Persons name is required.")]
    public virtual Person Name { get; set; }
    
    [Required(ErrorMessage = "Location is required.")]
    public virtual Location Location { get; set; }
