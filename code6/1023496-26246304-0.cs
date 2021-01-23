    public class CommentModelVM
    {
      [Required]
      public string Comment { get; set; }
      public string CommentByName { get; set; }
      [Display(Name="Your Department")] // add attributes associated with the view
      public string Department { get; set; }
      public SelectList DepartmentList { get; set } // to populate the dropdown options
    }
