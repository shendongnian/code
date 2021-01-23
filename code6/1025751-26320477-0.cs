    public class PersonalInformationViewModel
    {
      [Required]
      public int? Title {get;set;}
      public string FirstName {get;set;}
      public SelectList TitleList { get; set; }
    }
