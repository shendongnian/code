    public class MyViewModel
    {
      [Required]
      [Display(Name="Created by")]
      public int? CreatedBy { get; set; }
      [Required]
      public int? Responsible { get; set; }
      public int[] InterestedPersons { get; set; }
      public SelectList UserList { get; set; }
    }
