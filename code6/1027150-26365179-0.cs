    [Required(ErrorMessage = "You must select a country")]
    [Display(Name = "Country")]
    public int SelectedCountriesId { get; set; }
    public string CountryName { get; set; }
    public SelectList CountriesList { get; set; }
 
