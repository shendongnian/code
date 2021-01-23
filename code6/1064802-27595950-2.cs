    public class ParentVM
    {
      public int ParentID { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      [Required]
      public int? SelectedCourt { get; set; } // bind the dropdown to this
      public SelectList CourtList { get; set; }
      public IList<ChildVM> Children { get; set; } 
    }
