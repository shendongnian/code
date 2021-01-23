    public class RequirementVM
    {
      public int RequirementId { get; set; }
      public string Definition { get; set; }
      .... // other properties of Requirement that you want to edit
      [Required]
      [Display(Name="Created by")]
      public int? CreatedBy { get; set; }
      [Required]
      public int? Responsible { get; set; }
      public int[] InterestedPersons { get; set; }
      public SelectList UserList { get; set; }
    }
