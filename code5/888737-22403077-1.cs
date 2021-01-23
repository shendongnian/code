    [Required(ErrorMessage = "Preenchimento obrigatório.")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
    [Display(Name = "Data da DAU")]
    public DateTime? DAUData { get; set; }
