    public class CreateVM
    {
      [Display(Name = "Old name")]
      [Required]
      public string OldName { get; set; }
      [Display(Name = "New name")]
      [Required]
      public string NewName { get; set; }
      public SelectList CityList { get; set; }
    }
