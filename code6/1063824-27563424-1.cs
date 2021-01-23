    public class ViewModel
    {
          [Required]
          public string AssignedUserName { get; set; }
          public IList<SelectListItem> PossibleAssignees { get; set; }
          [Required]
          public string Comment { get; set; }
    }
