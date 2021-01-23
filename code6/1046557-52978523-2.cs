    [DisplayName("Country")]
    [Required(ErrorMessage = "Country is required")]
    public int CountryId { get; set; }
    [ForeignKey("CountryId")]
    public virtual Country Country { get; set; }
    [DisplayName("Currency")]
    [Required(ErrorMessage = "Currency is required")]
    public int CurrencyId { get; set; }
    [ForeignKey("CurrencyId")]
    public virtual Currency Currency { get; set; }
