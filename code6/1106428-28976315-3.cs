    public Class UserViewModel
    {
      ... // other properties of User
      [Display(Name = "Province")]
      [Required(ErrorMessage ="Please select a province")]
      public int ProvinceID { get; set; }
      public SelectList ProvinceList { get; set; }
    }
